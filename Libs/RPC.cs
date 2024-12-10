using DiscordRPC;

namespace AIMRPC.Libs
{
    internal class RPC
    {
        public static DiscordRpcClient? client;
        public static string application_id = "1214816314170941511";
        public static string buddy = "https://i.ibb.co/R4b6vXj/image.png";
        public static string aolguy = "https://i.ibb.co/ZGxx5yq/image.png";
        public static string awayaolguy = "https://i.ibb.co/cLzbr3c/away.png";
        public static void Init()
        {
            client = new DiscordRpcClient(application_id);
            client.OnReady += (sender, e) =>
            {
                Debug.Log($"Received Ready from user {e.User.Username}");
            };
            client.OnPresenceUpdate += (sender, e) =>
            {
                Debug.Log($"Received Update! {e.Presence}");
            };
            client.Initialize();
        }

        public static void UpdatePresence(string details = "", string state = "", string largeImageKey = "", string largeImageText = "", string smallImageKey = "", string smallImageText = "")
        {
            client?.SetPresence(new RichPresence()
            {
                Details = details,
                State = state,
                Assets = new Assets()
                {
                    LargeImageKey = largeImageKey,
                    LargeImageText = largeImageText,
                    SmallImageKey = smallImageKey,
                    SmallImageText = smallImageText
                }
            });
        }

        public static void ClearPresence() 
        {
            client?.ClearPresence();
        }

        public static void EmptyPresence()
        {
            RPC.UpdatePresence("", "", RPC.aolguy);
        }
    }
}
