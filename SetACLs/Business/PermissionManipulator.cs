using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Alphaleonis.Win32.Filesystem;
using SetACLs.Const;
using SetACLs.Model;

namespace SetACLs.Business
{
    public class PermissionManipulator
    {
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static AuthorizationRuleCollection GetDirectorySecurity(string path, bool isIncludeInherited = true)
        {
            try
            {
                return new DirectoryInfo(path)
                    .GetAccessControl()
                    .GetAccessRules(true, isIncludeInherited, typeof(NTAccount));
            }
            catch (UnauthorizedAccessException)
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
                catch (Exception exception)
                {
                    Logger.Error(exception);

                    Logger.Info("Parameters:" +
                                " \n+ Username:   {" + username +
                                "}\n+ Permission: {" + permission.Permission +
                                "}\n+ Domain:     {" + domain +
                                "}\n+ Folder:     {" + folderPath + "}");
                }
            }
        }

        public async Task AssignPermissionAsync(string folderPath, string domain, UserPermission permission)
        {
            foreach (var username in Regex.Split(permission.Username, "[;, ]").Where(p => !string.IsNullOrWhiteSpace(p)))
            {
                try
                {
                    var fileSystemRights = Permissions.Instance.All[permission.Permission].Item1;
                    var accessControlType = Permissions.Instance.All[permission.Permission].Item2;

                    var info = new DirectoryInfo(folderPath);

                    await Task.Run(() =>
                    {
                        var accessControl = info.GetAccessControl();

                        accessControl.AddAccessRule(new FileSystemAccessRule(
                            domain + @"\" + username,
                            fileSystemRights,
                            InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit,
                            PropagationFlags.None,
                            accessControlType));
                        info.SetAccessControl(accessControl);
                    });
                }
                catch (Exception exception)
                {
                    Logger.Error(exception);

                    Logger.Info("Parameters:" +
                                " \n+ Username:   {" + username +
                                "}\n+ Permission: {" + permission.Permission +
                                "}\n+ Domain:     {" + domain +
                                "}\n+ Folder:     {" + folderPath + "}");
                }
            }
        }

        public void EvictAllRightsFolderAndSubFoldersFromDomainUsers(string basePath, string domain)
        {
            EvictAllRightsCurrentFolderFromDomainUsers(basePath, domain);

            foreach (var info in new DirectoryInfo(basePath).GetDirectories())
            {
                EvictAllRightsFolderAndSubFoldersFromDomainUsers(info.FullName, domain);
            }
        }

        public void EvictAllRightsCurrentFolderFromDomainUsers(string path, string domain)
        {
            var info = new DirectoryInfo(path);
            var accessControl = info.GetAccessControl();
            var accessRules = accessControl.GetAccessRules(true, false, typeof(NTAccount));

            foreach (FileSystemAccessRule accessRule in accessRules)
            {
                if (string.IsNullOrWhiteSpace(domain) ||
                    !accessRule.IdentityReference.Value.StartsWith(domain + @"\", StringComparison.OrdinalIgnoreCase) &&
                    !accessRule.IdentityReference.Value.EndsWith("@" + domain, StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                accessControl.RemoveAccessRule(accessRule);
                accessControl.SetAccessRuleProtection(true, true);
            }

            try
            {
                info.SetAccessControl(accessControl);
            }
            catch (Exception e)
            {
                Logger.Error("Set permission error", e);
            }
        }

        public static IEnumerable<FileSystemAccessRule> GetPermissionsCurrentFolder(string path, string domain, bool isIncludeInherited = true)
        {
            return GetDirectorySecurity(path, isIncludeInherited)?.Cast<FileSystemAccessRule>()
                .Where(p => string.IsNullOrEmpty(domain) ||
                            p.IdentityReference.Value.StartsWith(domain + @"\", StringComparison.OrdinalIgnoreCase) ||
                            p.IdentityReference.Value.EndsWith("@" + domain, StringComparison.OrdinalIgnoreCase));
        }

        public IEnumerable<KeyValuePair<string, IEnumerable<FileSystemAccessRule>>> GetPermissionsSubFolders(string parentPath, string domain, bool isIncludeRootFolder = true, bool isIncludeInherited = true)
        {
            var allFoldersPermissions = new List<KeyValuePair<string, IEnumerable<FileSystemAccessRule>>>();
            if (isIncludeRootFolder)
            {
                allFoldersPermissions.Add(new KeyValuePair<string, IEnumerable<FileSystemAccessRule>>(parentPath,
                    GetPermissionsCurrentFolder(parentPath, domain, isIncludeInherited)));
            }

            foreach (var item in Directory.GetDirectories(parentPath)
                .Select((d, i) => new { Index = i, SubDirectory = d }))
            {
                var subDirectory = item.SubDirectory;

                var currentFolderPermissions = GetPermissionsCurrentFolder(subDirectory, domain, isIncludeInherited);

                allFoldersPermissions.Add(new KeyValuePair<string, IEnumerable<FileSystemAccessRule>>(subDirectory, currentFolderPermissions));
                allFoldersPermissions.AddRange(GetPermissionsSubFolders(subDirectory, domain, false, isIncludeInherited));
            }

            return allFoldersPermissions;
        }
    }
}
