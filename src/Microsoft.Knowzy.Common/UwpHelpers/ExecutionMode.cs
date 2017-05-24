using System.Runtime.InteropServices;
using System.Text;
using Windows.System.Profile;

namespace Microsoft.Knowzy.Common.UwpHelpers
{
    public class ExecutionMode
    {
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        static extern int GetCurrentPackageFullName(ref int packageFullNameLength, ref StringBuilder packageFullName);

        public static bool IsRunningAsUwp()
        {
            if (isWindows7OrLower())
            {
                return false;
            }
            else
            {
                StringBuilder sb = new StringBuilder(1024);
                int length = 0;
                int result = GetCurrentPackageFullName(ref length, ref sb);
                return result != 15700;
            }
        }

        private static bool isWindows7OrLower()
        {
            string deviceFamilyVersion = AnalyticsInfo.VersionInfo.DeviceFamilyVersion;
            ulong version = ulong.Parse(deviceFamilyVersion);
            ulong major = (version & 0xFFFF000000000000L) >> 48;
            ulong minor = (version & 0x0000FFFF00000000L) >> 32;
            double osVersion = (double)major + ((double)minor / 10.0);
            return osVersion <= 6.1;
        }
    }
}
