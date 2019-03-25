using System.Linq;
using Alphaleonis.Win32.Filesystem;

namespace SetACLs.Business
{
    public class DirectoryInfoExtractor
    {
        public static long DirectorySize_Byte(string path, bool isIncludeSubFolderSize = true)
        {
            var directoryInfo = new DirectoryInfo(path);

            var files = directoryInfo.GetFiles();
            var totalSize_Byte = files.Sum(fi => fi.Length);

            if (!isIncludeSubFolderSize)
            {
                return totalSize_Byte;
            }

            var subDirectories = directoryInfo.GetDirectories();
            totalSize_Byte += subDirectories.Sum(di => DirectorySize_Byte(di.FullName));

            return totalSize_Byte;
        }

        public static string GetBaseFolderPath(string path, bool isGetParent = true)
        {
            return isGetParent ? new DirectoryInfo(path).Parent?.FullName : path;
        }
    }
}
