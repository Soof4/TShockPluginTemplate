using IL.Terraria.GameContent.Biomes;
using Newtonsoft.Json;
using Terraria;
using TShockAPI;

namespace TShockPluginTemplate
{

    public class Config
    {
        public static string ConfigPath = Path.Combine(TShock.SavePath, "TShockPluginTemplateConfig.json");
        public string Property01 = "SomeDefaultValue";
        public int Property02 = 420;
        public static Config Reload()
        {
            Config? c = null;

            if (File.Exists(ConfigPath))
            {
                c = JsonConvert.DeserializeObject<Config>(File.ReadAllText(ConfigPath));
            }

            if (c == null)
            {
                c = new Config();
                File.WriteAllText(ConfigPath, JsonConvert.SerializeObject(c, Formatting.Indented));
            }

            return c;
        }
    }
}