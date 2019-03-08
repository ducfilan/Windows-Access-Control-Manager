using System;
using System.Collections.Generic;
using System.Security.AccessControl;
using SetACLs.Base;

namespace SetACLs.Const
{
	class Permissions : SingletonBase<Permissions>
	{
		private Permissions(){}

		public Dictionary<string, Tuple<FileSystemRights, AccessControlType>> All = new Dictionary<string, Tuple<FileSystemRights, AccessControlType>>
		{
			{ "R", new Tuple<FileSystemRights, AccessControlType>(FileSystemRights.ReadAndExecute, AccessControlType.Allow) },
			{ "M", new Tuple<FileSystemRights, AccessControlType>(FileSystemRights.Modify, AccessControlType.Allow) },
			{ "DM", new Tuple<FileSystemRights, AccessControlType>(FileSystemRights.Modify, AccessControlType.Deny) },
			{ "DR", new Tuple<FileSystemRights, AccessControlType>(FileSystemRights.ReadAndExecute, AccessControlType.Deny) },
			{ "N", new Tuple<FileSystemRights, AccessControlType>(FileSystemRights.Modify | FileSystemRights.ReadAndExecute, AccessControlType.Deny) }
		};
	}
}
