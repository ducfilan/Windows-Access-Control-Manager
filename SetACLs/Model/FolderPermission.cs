using System.Collections.Generic;

namespace SetACLs.Model
{
    public class FolderPermission
    {
        public string NodeKey { get; set; }
        public List<UserPermission> UserPermission { get; set; }
    }
}
