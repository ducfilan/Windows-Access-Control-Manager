using System;
using System.Collections.Generic;
using System.Security.AccessControl;
using SetACLs.Base;

namespace SetACLs.Const
{
	class Permissions : SingletonBase<Permissions>
	{
		private Permissions(){}

		public Dictionary<string, Tuple<FileSystemRights, AccessControlType, InheritanceFlags>> All = new Dictionary<string, Tuple<FileSystemRights, AccessControlType, InheritanceFlags>>
		{
			{ "L", new Tuple<FileSystemRights, AccessControlType, InheritanceFlags>
                (FileSystemRights.ReadAndExecute, AccessControlType.Allow, InheritanceFlags.ContainerInherit) },
			{ "R", new Tuple<FileSystemRights, AccessControlType, InheritanceFlags>
                (FileSystemRights.ReadAndExecute, AccessControlType.Allow, InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit) },
			{ "M", new Tuple<FileSystemRights, AccessControlType, InheritanceFlags>
                (FileSystemRights.Modify, AccessControlType.Allow, InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit) },
			{ "DM", new Tuple<FileSystemRights, AccessControlType, InheritanceFlags>
                (FileSystemRights.Modify, AccessControlType.Deny, InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit) },
			{ "DR", new Tuple<FileSystemRights, AccessControlType, InheritanceFlags>
                (FileSystemRights.ReadAndExecute, AccessControlType.Deny, InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit) },
			{ "N", new Tuple<FileSystemRights, AccessControlType, InheritanceFlags>
                (FileSystemRights.Modify | FileSystemRights.ReadAndExecute, AccessControlType.Deny, InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit) }
		};
	}
}
