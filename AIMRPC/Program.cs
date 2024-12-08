using AIMRPC.Libs;

namespace AIMRPC
{
    class Program
    {
        static bool compatThing = false;
        private static void Init()
        {
            ProcessHandler.InitilizeAIM();
            RPC.Init();
            Config.ReadConfig();
            Debug.Log("AIMRPC has been started!", Debug.Level.MESSAGE);
        }
        public static void Main()
        {
            Init();
            while (true)
            {
                if (AIMHandler.AIMRunningInCompat() && compatThing)
                {
                    Debug.Log("AIM is running in Compatability Mode, you will not gain any support!", Debug.Level.FATAL);
                    compatThing = true;
                }
                if (AIMHandler.IsAIMOpened())
                {
                    AIMHandler.SetScreenName();
                    switch (AIMHandler.AIMActivity())
                    {
                        case AIMHandler.State.SIGNING_ON:
                            RPC.UpdatePresence("Signing On..", string.Empty, RPC.aolguy, AIMHandler.screenName);
                            break;
                        case AIMHandler.State.BUDDYLIST:
                            RPC.UpdatePresence("Looking at Buddy List", string.Empty, RPC.aolguy, AIMHandler.screenName);
                            break;
                        case AIMHandler.State.CHATTING:
                            RPC.UpdatePresence(AIMHandler.ReturnCurrentBuddy(), string.Empty, RPC.aolguy, AIMHandler.screenName, RPC.buddy);
                            break;
                        case AIMHandler.State.PREFERENCES:
                            RPC.UpdatePresence("Looking at Preferences", string.Empty, RPC.aolguy, AIMHandler.screenName);
                            break;
                        case AIMHandler.State.AVAILABLE:
                            RPC.UpdatePresence("Available", string.Empty, RPC.aolguy, AIMHandler.screenName);
                            break;
                        case AIMHandler.State.EDITING_PROFILE:
                            RPC.UpdatePresence("Editing their Profile", string.Empty, RPC.aolguy, AIMHandler.screenName);
                            break;
                        case AIMHandler.State.INVITING_TO_CHAT:
                            RPC.UpdatePresence("Inviting people to Chat", string.Empty, RPC.aolguy, AIMHandler.screenName, RPC.buddy);
                            break;
                        case AIMHandler.State.NEUTRAL:
                            RPC.EmptyPresence();
                            break;
                    }
                }
                else
                {
                    RPC.ClearPresence();
                }
            }
        }
    }
}

