using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text.RegularExpressions;
using SetACLs.Const;
using SetACLs.Model;

namespace SetACLs.Business
{
	public class PermissionManipulator
	{
		public static AuthorizationRuleCollection GetDirectorySecurity(string path)
        {
            try
            {
                return new DirectoryInfo(path)
                    .GetAccessControl()
                    .GetAccessRules(true, true, typeof(NTAccount));
            }
            catch (UnauthorizedAccessException )
            {
                // Ignore.
            }

            return null;
        }

		public void AssignPermission(string folderPath, string domain, UserPermission permission)
		{
			foreach (var username in Regex.Split(permission.Username, "[;, ]").Where(p => !string.IsNullOrWhiteSpace(p)))
			{
				try
				{
					var fileSystemRights = Permissions.Instance.All[permission.Permission].Item1;
					var accessControlType = Permissions.Instance.All[permission.Permission].Item2;

					var info = new DirectoryInfo(folderPath);
					var accessControl = info.GetAccessControl();

                    accessControl.AddAccessRule(new FileSystemAccessRule(
						domain + @"\" + username,
						fileSystemRights,
						InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit,
						PropagationFlags.None,
						accessControlType));
					info.SetAccessControl(accessControl);
				}
				catch
				{
					throw new Exception("Your template's data may have been wrong! Check the parameters:" + 
                                        " \n+ Username:   {" + username +
                                        "}\n+ Permission: {" + permission.Permission +
                                        "}\n+ Domain:     {" + domain + 
                                        "}\n+ Folder:     {" + folderPath + "}");
				}
			}
		}

        public void EvictAllRightsFromDomainUsers(string basePath, string domain)
        {
            foreach (var info in new DirectoryInfo(basePath).GetDirectories())
            {
                var accessControl = info.GetAccessControl();
                var accessRules = accessControl.GetAccessRules(true, false, typeof(NTAccount));

                foreach (FileSystemAccessRule accessRule in accessRules)
                {
                    if (string.IsNullOrWhiteSpace(domain) || !accessRule.IdentityReference.Value.StartsWith(domain))
                    {
                        continue;
                    }

                    accessControl.RemoveAccessRule(accessRule);
                    accessControl.SetAccessRuleProtection(true, true);
                }

                info.SetAccessControl(accessControl);

                EvictAllRightsFromDomainUsers(info.FullName, domain);
            }
        }

        public static IEnumerable<FileSystemAccessRule> GetPermissionsCurrentFolder(string path, string domain)
        {
            return GetDirectorySecurity(path)?.Cast<FileSystemAccessRule>()
                .Where(p => string.IsNullOrEmpty(domain) ||
                            p.IdentityReference.Value.StartsWith(domain, StringComparison.OrdinalIgnoreCase) ||
                            p.IdentityReference.Value.EndsWith(domain, StringComparison.OrdinalIgnoreCase));
		}

        public IEnumerable<KeyValuePair<string, IEnumerable<FileSystemAccessRule>>> GetPermissionsSubFolders(string parentPath, string domain)
        {
	        var allFoldersPermissions = new List<KeyValuePair<string, IEnumerable<FileSystemAccessRule>>>();

	        foreach (var item in Directory.GetDirectories(parentPath)
		        .Select((d, i) => new { Index = i, SubDirectory = d }))
	        {
		        var subDirectory = item.SubDirectory;

		        var currentFolderPermissions = GetPermissionsCurrentFolder(subDirectory, domain);

		        allFoldersPermissions.Add(new KeyValuePair<string, IEnumerable<FileSystemAccessRule>>(subDirectory, currentFolderPermissions));
		        allFoldersPermissions.AddRange(GetPermissionsSubFolders(subDirectory, domain));
	        }

	        return allFoldersPermissions;
        }
	}
}
