using System.Diagnostics;
using System.Text.RegularExpressions;

namespace AIMRPC.Libs
{
    internal class AIMHandler
    {
        public static string screenName = string.Empty;
        public static State currentState;
        public enum State
        {
            SIGNING_ON,
            CHATTING,
            AWAY,
            BUDDYLIST,
            PREFERENCES,
            AVAILABLE,
            EDITING_PROFILE,
            INVITING_TO_CHAT,
            NEUTRAL
        }
        private static Dictionary<string, State> stateMappings = new Dictionary<string, State>(StringComparer.OrdinalIgnoreCase)
        {
            { "Sign On", State.SIGNING_ON },
            { "Instant Message", State.CHATTING },
            { "Chat Room", State.CHATTING },
            { "Buddy List Window", State.BUDDYLIST },
            { "Preferences", State.PREFERENCES },
            { "Create a Profile", State.EDITING_PROFILE },
            { "Chat Invitation", State.INVITING_TO_CHAT }
        };


        public static bool IsAIMOpened()
        {
            if (ProcessHandler.InitilizeAIM())
                return true;
            Debug.Log("We were trying to check for AIM, but AIM was not found!", Debug.Level.WARN);
            return false;
        }

        public static bool AIMRunningInCompat()
        {
            foreach (Process child in Process.GetProcessesByName("aim"))
            {
                if (child.MainWindowTitle.Contains("compat", StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }

        public static Enum AIMActivity()
        {
            if (IsAIMOpened())
            {
                foreach (Process child in Process.GetProcessesByName("aim"))
                {
                    if (isAway())
                    {
                        return State.AWAY;
                    }

                    foreach (var mapping in stateMappings)
                    {
                        if (child.MainWindowTitle.Contains(mapping.Key, StringComparison.OrdinalIgnoreCase))
                        {
                            if (currentState != mapping.Value)
                            {
                                currentState = mapping.Value;
                                Debug.Log($"{mapping.Key} detected");
                            }
                            return mapping.Value;
                        }
                    }
                    return State.AVAILABLE;
                }
            }
            return State.NEUTRAL;
        }

        public static bool isAway()
        {
            if (IsAIMOpened())
            {
                foreach (Process child in Process.GetProcessesByName("aim"))
                {
                    foreach (var mapping in stateMappings)
                    {
                        if (!child.MainWindowTitle.Contains(mapping.Key, StringComparison.OrdinalIgnoreCase))
                        {
                           if (ProcessHandler.getButtonsInWindow(child.MainWindowTitle) != null)
                            {
                                string[] buttons = ProcessHandler.getButtonsInWindow(child.MainWindowTitle);
                                foreach (string button in buttons)
                                {
                                    if (button.Contains("I'm Back", StringComparison.OrdinalIgnoreCase))
                                    {
                                        return true;
                                    }
                                }
                            }
                        }
                    }
                }
                return false;
            }
            return false;
        }

        public static string ReturnCurrentBuddy()
        {
            if (IsAIMOpened() && AIMActivity() is State.CHATTING)
            {
                foreach (Process child in Process.GetProcessesByName("aim"))
                {
                    if (child.MainWindowTitle.Contains("Instant Message", StringComparison.OrdinalIgnoreCase))
                    {
                        if (child.MainWindowTitle == "Instant Message")
                            return "Writing new chat";
                        string name = child.MainWindowTitle.Split(new[] { " - Instant Message" }, StringSplitOptions.None)[0].Trim();
                        return $"Chatting with {name}";
                    }
                    else if (child.MainWindowTitle.Contains("Chat Room", StringComparison.OrdinalIgnoreCase))
                    {
                        string name = Regex.Replace(child.MainWindowTitle, @"\D", string.Empty).Trim();
                        return $"Chatting in Chat Room {name}";
                    }
                }
            }
            return string.Empty;
        }

        public static void SetScreenName()
        {
            if (IsAIMOpened() && AIMActivity() is State.BUDDYLIST)
            {
                foreach (Process child in Process.GetProcessesByName("aim"))
                {
                    string name = child.MainWindowTitle.Split(new[] { "'s Buddy List Window" }, StringSplitOptions.None)[0].Trim();
                    screenName = "Logged in as " + name;
                }
            }
        }
    }
}
