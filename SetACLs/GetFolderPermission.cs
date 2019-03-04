using System.Collections.Generic;
using System.IO;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace SetACLs
{
    internal class GetFolderPermission
    {
        public string Path { get; set; }

        public GetFolderPermission(string path)
        {
            this.Path = path;
        }
        
        readonly List<PermissionsModel> _userPermission = new List<PermissionsModel>();

        public async Task<List<PermissionsModel>> GetPermissionAsync()
        {
            var dInfo = new DirectoryInfo(Path);
            var dSecurity = dInfo.GetAccessControl();
            var acl = await Task.Run(() => dSecurity.GetAccessRules(true, true, typeof(System.Security.Principal.NTAccount)));
            foreach (FileSystemAccessRule ace in acl)
            {
	            var perModel = new PermissionsModel
	            {
		            IdentityReference = ace.IdentityReference.Value,
		            AccessControlType = ace.AccessControlType.ToString(),
		            FileSystemRights = FileSystemRightsCorrector(ace.FileSystemRights, false).ToString(),
		            IsInherited = ace.IsInherited
	            };
	            _userPermission.Add(perModel);
            }

            return _userPermission;
        }
        
        public FileSystemRights FileSystemRightsCorrector(FileSystemRights fsRights, bool removeSynchronizePermission = false)
        {
            const int cBitGenericRead = (1 << 31);
            const int cBitGenericWrite = (1 << 30);
            const int cBitGenericExecute = (1 << 29);
            const int cBitGenericAll = (1 << 28);

            const FileSystemRights cFsrGenericRead = FileSystemRights.ReadAttributes | FileSystemRights.ReadData | FileSystemRights.ReadExtendedAttributes | FileSystemRights.ReadPermissions | FileSystemRights.Synchronize;
            const FileSystemRights cFsrGenericWrite = FileSystemRights.AppendData | FileSystemRights.WriteAttributes | FileSystemRights.WriteData | FileSystemRights.WriteExtendedAttributes | FileSystemRights.ReadPermissions | FileSystemRights.Synchronize;
            const FileSystemRights cFsrGenericExecute = FileSystemRights.ExecuteFile | FileSystemRights.ReadAttributes | FileSystemRights.ReadPermissions | FileSystemRights.Synchronize;

            if (((int)fsRights & cBitGenericRead) != 0)
            {
                fsRights |= cFsrGenericRead;
            }

            if (((int)fsRights & cBitGenericWrite) != 0)
            {
                fsRights |= cFsrGenericWrite;
            }

            if (((int)fsRights & cBitGenericExecute) != 0)
            {
                fsRights |= cFsrGenericExecute;
            }

            if (((int)fsRights & cBitGenericAll) != 0)
            {
                fsRights |= FileSystemRights.FullControl;
            }

            fsRights = (FileSystemRights)((int)fsRights & ~(cBitGenericRead | cBitGenericWrite | cBitGenericExecute | cBitGenericAll));


            if (removeSynchronizePermission)
            {
                fsRights = (FileSystemRights)((int)fsRights & ~((int)FileSystemRights.Synchronize));
            }

            return fsRights;
        }
    }
}
