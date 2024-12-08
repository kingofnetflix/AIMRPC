using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Management;

namespace AIMRPC.Libs
{
    #pragma warning disable CA1416 // fuck other platforms, just use windows
    internal class ProcessHandler
    {
        public static Process? aim;
        public static bool InitilizeAIM()
        {
            Process[] aims = Process.GetProcessesByName("aim");
            if (aims.Length > 0)
            {
                aim = aims[0];
                return true;
            }
            else if (aims.Length < 0)
            {
                aim = null;
                return false;
            }
            return false;
        }
    }
}
