using System;
using System.Diagnostics;
using System.Security.Principal;
using System.Windows.Forms;

namespace SetACLs.Business
{
    public class StartAsAdminManipulator
    {
        public static bool IsAdmin()
        {
            var id = WindowsIdentity.GetCurrent();

            var p = new WindowsPrincipal(id);
            return p.IsInRole(WindowsBuiltInRole.Administrator);
        }

        public static void RestartElevated()
        {
            var startInfo = new ProcessStartInfo
            {
                UseShellExecute = true,
                CreateNoWindow = true,
                WorkingDirectory = Environment.CurrentDirectory,
                FileName = Application.ExecutablePath,
                Verb = "runas"
            };
            try
            {
                Process.Start(startInfo);
            }
            catch { }

            Application.Exit();
        }
    }
}
