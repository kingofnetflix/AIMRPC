using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIMRPC.Libs
{
    internal class Debug
    {
        public static Level level = Level.MESSAGE;
        public static void Log(object message, Level logLevel = Level.INFO, bool forced = false)
        {
            if (logLevel < level && !forced)
                return;
            switch (logLevel)
            {
                case Level.INFO:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case Level.WARN:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case Level.ERROR:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case Level.FATAL:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    break;
                case Level.MESSAGE:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }
            Console.WriteLine($"[{logLevel}]: {message}");
            Console.ResetColor();
        }
        public enum Level
        {
            INFO,
            WARN,
            ERROR,
            FATAL,
            MESSAGE
        }
    }
}
