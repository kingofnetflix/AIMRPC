using Newtonsoft.Json.Linq;

namespace AIMRPC.Libs
{
    internal class Config
    {
        #pragma warning disable CS8602
        static readonly string file = AppDomain.CurrentDomain.BaseDirectory + "config.json";
        static readonly bool debug = false;
        public static void ReadConfig()
        {
            if (!debug)
            {
                Debug.Log("Config is stored at " + file);
                if (File.Exists(file))
                {
                    string json = File.ReadAllText(file);
                    JObject obj = JObject.Parse(json);
                    RPC.application_id = obj["application_id"].ToString();
                    if (Enum.TryParse<Debug.Level>(obj["debug_level"].ToString(), out var level))
                        Debug.level = level;
                }
                else if (!File.Exists(file))
                {
                    Debug.Log("Config file not found, creating one now...");
                    JObject obj = new()
                    {
                        ["application_id"] = RPC.application_id.ToString(),
                        ["debug_level"] = Debug.level.ToString()
                    };
                    File.WriteAllText(file, obj.ToString());
                }
            }
            else if (debug) { Debug.Log("Debug mode is enabled! Config will not be loaded.", Debug.Level.WARN, true); }
            else { Debug.Log("There was an error loading the config! Please report this to the repository", Debug.Level.FATAL, true); }
            
        }
    }
}
