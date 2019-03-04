namespace SetACLs
{
    using System.Collections.Generic;
    using System.DirectoryServices;
    using System.DirectoryServices.AccountManagement;
    using System.IO;
    using System.Security.AccessControl;
    using System.Security.Principal;

    internal class FacHelper
    {
        private const FileSystemRights FsrFull = FileSystemRights.FullControl;
        private const FileSystemRights FsrList = (FileSystemRights.Synchronize | FileSystemRights.ReadAndExecute);
        private const FileSystemRights FsrModify = (FileSystemRights.Synchronize | FileSystemRights.Modify);
        private const FileSystemRights FsrRemoveAll = FileSystemRights.FullControl;
        private const FileSystemRights FsrRemoveFull = FileSystemRights.FullControl;
        private const FileSystemRights FsrRemoveModify = FileSystemRights.FullControl;
        private const InheritanceFlags InheritFlags = (InheritanceFlags.ObjectInherit | InheritanceFlags.ContainerInherit);

        public void AddAllowRightFull(string path, string account)
        {
            AddDirectorySecurity(path, account, FileSystemRights.FullControl, InheritanceFlags.None, PropagationFlags.None, AccessControlType.Allow);
        }

        public void AddAllowRightList(string path, string account)
        {
            AddDirectorySecurity(path, account, FileSystemRights.Synchronize | FileSystemRights.ReadAndExecute, InheritanceFlags.ObjectInherit | InheritanceFlags.ContainerInherit, PropagationFlags.None, AccessControlType.Allow);
        }

        public void AddAllowRightListNotInherit(string path, string account)
        {
            AddDirectorySecurity(path, account, FileSystemRights.Synchronize | FileSystemRights.ReadAndExecute, InheritanceFlags.None, PropagationFlags.None, AccessControlType.Allow);
        }

        public void AddAllowRightModify(string path, string account)
        {
            AddDirectorySecurity(path, account, FileSystemRights.Synchronize | FileSystemRights.Modify, InheritanceFlags.ObjectInherit | InheritanceFlags.ContainerInherit, PropagationFlags.None, AccessControlType.Allow);
        }

        public void AddAllowRightModifyNotInherit(string path, string account)
        {
            AddDirectorySecurity(path, account, FileSystemRights.Synchronize | FileSystemRights.Modify, InheritanceFlags.None, PropagationFlags.None, AccessControlType.Allow);
        }

        public void AddDenyRightFull(string path, string account)
        {
            AddDirectorySecurity(path, account, FileSystemRights.FullControl, InheritanceFlags.ObjectInherit | InheritanceFlags.ContainerInherit, PropagationFlags.None, AccessControlType.Deny);
        }

        public void AddDenyRightList(string path, string account)
        {
            AddDirectorySecurity(path, account, FileSystemRights.Synchronize | FileSystemRights.ReadAndExecute, InheritanceFlags.ObjectInherit | InheritanceFlags.ContainerInherit, PropagationFlags.None, AccessControlType.Deny);
        }

        public void AddDenyRightListNotInherit(string path, string account)
        {
            AddDirectorySecurity(path, account, FileSystemRights.Synchronize | FileSystemRights.ReadAndExecute, InheritanceFlags.None, PropagationFlags.None, AccessControlType.Deny);
        }

        public void AddDenyRightModify(string path, string account)
        {
            AddDirectorySecurity(path, account, FileSystemRights.Synchronize | FileSystemRights.Delete | FileSystemRights.Write | FileSystemRights.DeleteSubdirectoriesAndFiles, InheritanceFlags.ObjectInherit | InheritanceFlags.ContainerInherit, PropagationFlags.None, AccessControlType.Deny);
        }

        public void AddDenyRightModifyNotInherit(string path, string account)
        {
            AddDirectorySecurity(path, account, FileSystemRights.Synchronize | FileSystemRights.Delete | FileSystemRights.Write | FileSystemRights.DeleteSubdirectoriesAndFiles, InheritanceFlags.None, PropagationFlags.None, AccessControlType.Deny);
        }

        public void AddDirectorySecurity(string path, string account, FileSystemRights rights, InheritanceFlags inheritance, PropagationFlags propogation, AccessControlType controlType)
        {
            var info = new DirectoryInfo(path);
            var accessControl = info.GetAccessControl();
            accessControl.AddAccessRule(new FileSystemAccessRule(account, rights, inheritance, propogation, controlType));
            info.SetAccessControl(accessControl);
        }

        public bool DoesUserExist(string userName)
        {
            bool flag;
            var context = new PrincipalContext(ContextType.Domain);
            try
            {
                var objA = GroupPrincipal.FindByIdentity(context, IdentityType.SamAccountName, userName);
                try
                {
                    if (!ReferenceEquals(objA, null))
                    {
                        return true;
                    }
                }
                finally
                {
                    if (!ReferenceEquals(objA, null))
                    {
                        objA.Dispose();
                    }
                }
                var principal2 = UserPrincipal.FindByIdentity(context, IdentityType.SamAccountName, userName);
                try
                {
                    context.Dispose();
                    flag = !ReferenceEquals(principal2, null);
                }
                finally
                {
                    if (!ReferenceEquals(principal2, null))
                    {
                        principal2.Dispose();
                    }
                }
            }
            finally
            {
                if (!ReferenceEquals(context, null))
                {
                    context.Dispose();
                }
            }
            return flag;
        }

        public AuthorizationRuleCollection GetDirectorySecurity(string path) => 
            new DirectoryInfo(path).GetAccessControl().GetAccessRules(true, true, typeof(NTAccount));

        public FileSystemAccessRule GetDirectorySecurity(string path, string accountName)
        {
            var rules = new DirectoryInfo(path).GetAccessControl().GetAccessRules(true, true, typeof(NTAccount));
            FileSystemAccessRule rule = null;
            for (var i = 0; i < rules.Count; i++)
            {
                if (((FileSystemAccessRule) rules[i]).IdentityReference.Value.Equals(accountName))
                {
                    rule = (FileSystemAccessRule) rules[i];
                    i = rules.Count;
                }
            }
            return rule;
        }

        public string GetFriendlyRightName(FileSystemAccessRule frs)
        {
            string str;
            var fileSystemRights = frs.FileSystemRights;
            if (frs.AccessControlType != AccessControlType.Deny)
            {
                if (fileSystemRights == (FileSystemRights.Synchronize | FileSystemRights.ReadAndExecute))
                {
                    str = (frs.InheritanceFlags != InheritanceFlags.None) ? "Read and Execute" : "Read and Execute Not Inherit";
                }
                else if (fileSystemRights == (FileSystemRights.Synchronize | FileSystemRights.Modify))
                {
                    str = (frs.InheritanceFlags != InheritanceFlags.None) ? "Modify" : "Modify Not Inherit";
                }
                else
                {
                    str = (fileSystemRights != FileSystemRights.FullControl) ? "Others" : "Full Control";
                }
            }
            else
            {
                if (fileSystemRights != (FileSystemRights.Synchronize | FileSystemRights.ReadAndExecute))
                {
                    if (fileSystemRights != (FileSystemRights.Delete | FileSystemRights.Write | FileSystemRights.DeleteSubdirectoriesAndFiles))
                    {
                        if (fileSystemRights == FileSystemRights.FullControl)
                        {
                            return "Deny Full Control";
                        }
                    }
                    else
                    {
                        return "Deny Modify";
                    }
                }
                str = "Deny Read and Execute";
            }
            return str;
        }

        public List<string> GetUserListFromAd()
        {
            var list = new List<string>();
            var results = new DirectorySearcher(new DirectoryEntry()) { Filter = "(&(objectCategory=person))" }.FindAll();
            for (var i = 0; i < results.Count; i++)
            {
                var result = results[i];
                if (list.IndexOf(result.Properties["cn"][0].ToString().ToUpper()) <= 0)
                {
                    list.Add(result.Properties["cn"][0].ToString().ToUpper());
                }
            }
            return list;
        }

        public bool IsFullRight(FileSystemRights frs) => 
            (FileSystemRights.FullControl == frs);

        public bool IsListRight(FileSystemRights frs) => 
            ((FileSystemRights.Synchronize | FileSystemRights.ReadAndExecute) == frs);

        public bool IsModifyRight(FileSystemRights frs) => 
            ((FileSystemRights.Synchronize | FileSystemRights.Modify) == frs);

        public void RemoveDenyRightList(string path, string account)
        {
            RemoveDirectorySecurity(path, account, FileSystemRights.Synchronize | FileSystemRights.ReadAndExecute, AccessControlType.Deny);
        }

        public void RemoveDenyRightModify(string path, string account)
        {
            RemoveDirectorySecurity(path, account, FileSystemRights.Synchronize | FileSystemRights.Delete | FileSystemRights.Write | FileSystemRights.DeleteSubdirectoriesAndFiles, AccessControlType.Deny);
        }

        public void RemoveDirectorySecurity(string path, string account, FileSystemRights rights, AccessControlType controlType)
        {
            var info = new DirectoryInfo(path);
            var accessControl = info.GetAccessControl();
            accessControl.RemoveAccessRuleAll(new FileSystemAccessRule(account, rights, controlType));
            accessControl.RemoveAccessRule(new FileSystemAccessRule(account, rights, controlType));
            info.SetAccessControl(accessControl);
        }

        public void RemoveInheritablePermissions(string path)
        {
            var info = new DirectoryInfo(path);
            var accessControl = info.GetAccessControl();
            accessControl.SetAccessRuleProtection(true, false);
            info.SetAccessControl(accessControl);
        }

        public void RemoveRightAll(string path, string account)
        {
	        var directorySecurity = GetDirectorySecurity(path);
            var info = new DirectoryInfo(path);
            var accessControl = info.GetAccessControl();
            var num = 0;
            while (true)
            {
                if (num >= directorySecurity.Count)
                {
                    accessControl.SetAccessRuleProtection(true, false);
                    accessControl.RemoveAccessRuleAll(new FileSystemAccessRule(account, FileSystemRights.FullControl, AccessControlType.Allow));
                    accessControl.RemoveAccessRuleAll(new FileSystemAccessRule(account, FileSystemRights.FullControl, AccessControlType.Deny));
                    accessControl.RemoveAccessRuleAll(new FileSystemAccessRule(account, FileSystemRights.ReadAndExecute, AccessControlType.Allow));
                    accessControl.RemoveAccessRuleAll(new FileSystemAccessRule(account, FileSystemRights.ReadAndExecute, AccessControlType.Deny));
                    accessControl.RemoveAccessRuleAll(new FileSystemAccessRule(account, FileSystemRights.Modify, AccessControlType.Allow));
                    accessControl.RemoveAccessRuleAll(new FileSystemAccessRule(account, FileSystemRights.Modify, AccessControlType.Deny));
                    info.SetAccessControl(accessControl);
                    return;
                }
                var rule = (FileSystemAccessRule) directorySecurity[num];
                if (rule.IsInherited)
                {
                    accessControl.AddAccessRule(new FileSystemAccessRule(rule.IdentityReference.Value, rule.FileSystemRights, rule.InheritanceFlags, rule.PropagationFlags, rule.AccessControlType));
                }
                num++;
            }
        }

        public void RemoveRightFull(string path, string account)
        {
            RemoveDirectorySecurity(path, account, FileSystemRights.FullControl, AccessControlType.Allow);
        }

        public void RemoveRightModify(string path, string account)
        {
            RemoveDirectorySecurity(path, account, FileSystemRights.FullControl, AccessControlType.Allow);
        }

        public enum FsrFriendlyName
        {
            FullControl,
            List,
            Modify,
            Others
        }
    }
}

