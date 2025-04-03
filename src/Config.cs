using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Modules.Extensions;
using System.Text.Json.Serialization;

namespace ChatInfo
{
    public class InfoMessagesConfig
    {
        [JsonPropertyName("description")] public Dictionary<string, string> Description { get; set; } = [];
        [JsonPropertyName("sub_commands")] public Dictionary<string, InfoMessagesConfig> SubCommands { get; set; } = [];
    }

    public class PluginConfig : BasePluginConfig
    {
        // disabled
        [JsonPropertyName("enabled")] public bool Enabled { get; set; } = true;
        // debug prints
        [JsonPropertyName("debug")] public bool Debug { get; set; } = false;
        // info messages
        [JsonPropertyName("messages")] public Dictionary<string, InfoMessagesConfig> Messages { get; set; } = [];
    }

    public partial class ChatInfo : BasePlugin, IPluginConfig<PluginConfig>
    {
        public required PluginConfig Config { get; set; }

        public void OnConfigParsed(PluginConfig config)
        {
            Config = config;
            // sort messages by key
            Config.Messages = Config.Messages.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
            // update config and write new values from plugin to config file if changed after update
            Config.Update();
            Console.WriteLine(Localizer["core.config"]);
        }
    }
}
