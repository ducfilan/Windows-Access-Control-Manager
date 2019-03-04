using System;
using System.IO;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace SharedDrivePerms
{
    internal class SetFolderPermission
    {
        
        public string Group { get; set; }
        public string FolderPath { get; set; }
        public string AccessType { get; set; }


        public SetFolderPermission(string _group, string _folderpath, string _accesstype)
        {
            this.Group = _group;
            this.FolderPath = _folderpath;
            this.AccessType = _accesstype;
        }


        public async void AddFolderPermission()
        {
            try
            {
                var directoryInfo = new DirectoryInfo(FolderPath);
                var directorySecurity = directoryInfo.GetAccessControl();
                //var currentUserIdentity = WindowsIdentity.GetCurrent();

                if (AccessType.Equals("Read Only"))
                {
                    var fileSystemRule = new FileSystemAccessRule(Group,
                                                                  FileSystemRights.Read,
                                                                  InheritanceFlags.ObjectInherit |
                                                                  InheritanceFlags.ContainerInherit,
                                                                  PropagationFlags.None,
                                                                  AccessControlType.Allow);
                    await Task.Run(() =>
                    {
                        try
                        {
                            directorySecurity.AddAccessRule(fileSystemRule);
                            directoryInfo.SetAccessControl(directorySecurity);
                        }
                        catch(Exception ex)
                        {
                            throw ex;
                        }
                    });

                }
                if (AccessType.Equals("Modify"))
                {
                    var fileSystemRule = new FileSystemAccessRule(Group,
                                                                  FileSystemRights.Modify,
                                                                  InheritanceFlags.ObjectInherit |
                                                                  InheritanceFlags.ContainerInherit,
                                                                  PropagationFlags.None,
                                                                  AccessControlType.Allow);
                    await Task.Run(() =>
                    {
                        directorySecurity.AddAccessRule(fileSystemRule);
                        directoryInfo.SetAccessControl(directorySecurity);
                    });
                }
            }
            catch(Exception ex)
            {
                if(ex is System.UnauthorizedAccessException)
                {
                    throw ex;
                }
                else
                {
                    throw ex;
                }
                
            }

        }

    }
}
