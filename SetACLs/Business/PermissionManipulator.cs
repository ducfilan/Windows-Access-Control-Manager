using System;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using SetACLs.Const;
using SetACLs.Model;

namespace SetACLs.Business
{
	public class PermissionManipulator
	{
		public AuthorizationRuleCollection GetDirectorySecurity(string path) =>
			new DirectoryInfo(path).GetAccessControl().GetAccessRules(true, true, typeof(NTAccount));

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
					throw new Exception("Your template's data may have been wrong! Check the parameters: \n+ Username: {" + username +
                                        "}\n+ Permission: {" + permission.Permission +
                                        "}\n+ Domain: {" + domain + 
                                        "}\n+ Folder: {" + folderPath + "}");
				}
			}
		}
	}
}
