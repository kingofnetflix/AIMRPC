using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Management;
using System.Runtime.InteropServices;
using System.Text;

namespace AIMRPC.Libs
{
    #pragma warning disable CA1416 // fuck other platforms, just use windows
    internal class ProcessHandler
    {

        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);
        [DllImport("user32.dll", SetLastError = true)]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);
        [DllImport("user32.dll", SetLastError = true)]
        private static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);

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
        public static string[] getButtonsInWindow(string winTitle)
        {
            string[] buttons = new string[0];
            IntPtr win = FindWindow(null, winTitle);
            if (win == IntPtr.Zero)
            {
                Debug.Log("Window not found", Debug.Level.ERROR);
                return null;
            }
            IntPtr child = IntPtr.Zero;
            while (true)
            {
                child = FindWindowEx(win, child, null, null);
                if (child == IntPtr.Zero)
                    break;
                StringBuilder sb = new StringBuilder(256);
                GetClassName(child, sb, sb.Capacity);
                if (sb.ToString() == "Button")
                {
                    sb.Clear();
                    GetWindowText(child, sb, sb.Capacity);
                    Array.Resize(ref buttons, buttons.Length + 1);
                    buttons[buttons.Length - 1] = sb.ToString();
                }

            }
            return buttons;
        }
    }
}
