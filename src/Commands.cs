using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Core.Attributes.Registration;
using CounterStrikeSharp.API.Core.Translations;
using CounterStrikeSharp.API.Modules.Commands;
using CounterStrikeSharp.API.Modules.Extensions;
using CounterStrikeSharp.API.Modules.Menu;

namespace ChatInfo
{
    public partial class ChatInfo
    {
        [ConsoleCommand("?", "shows all commands on this server")]
        [ConsoleCommand("commands", "shows all commands on this server")]
        [ConsoleCommand("help", "shows all commands on this server")]
        [ConsoleCommand("info", "shows all commands on this server")]
        [CommandHelper(whoCanExecute: CommandUsage.CLIENT_ONLY, minArgs: 0, usage: "")]
        public void CommandInfo(CCSPlayerController player, CommandInfo command)
        {
            if (Config.Messages.Count == 0)
            {
                return;
            }
            // close any active menu
            MenuManager.CloseActiveMenu(player);
            // create menu to choose map
            ChatMenu menu = new(Localizer["menu.title"]);
            foreach (KeyValuePair<string, InfoMessagesConfig> kvp in Config.Messages)
            {
                string description = kvp.Value.Description.TryGetValue(PlayerLanguageExtensions.GetLanguage(player).TwoLetterISOLanguageName, out string? userDescription)
                ? userDescription
                : (kvp.Value.Description.TryGetValue(CoreConfig.ServerLanguage, out string? serverDescription)
                    ? serverDescription
                    : kvp.Value.Description.First().Value);
                _ = menu.AddMenuOption(kvp.Key + " = " + ReplaceChatColors(description),
            (_, _) => DisplaySubCommands(player, kvp.Key),
            kvp.Value.SubCommands.Count <= 0);
            }
            // open menu
            MenuManager.OpenChatMenu(player, menu);
        }

        private void DisplaySubCommands(CCSPlayerController player, string commandName)
        {
            Console.WriteLine($"DisplaySubCommands: {commandName}");
            if (player == null
                || !player.IsValid
                || !Config.Messages.TryGetValue(commandName, out InfoMessagesConfig? command)
                || command.SubCommands.Count == 0)
            {
                return;
            }
            // close any active menu
            MenuManager.CloseActiveMenu(player);
            // create menu to choose map
            ChatMenu menu = new(Localizer["menu.subtitle"].Value
                .Replace("{command}", commandName));
            foreach (KeyValuePair<string, InfoMessagesConfig> kvp in command.SubCommands)
            {
                string description = kvp.Value.Description.TryGetValue(PlayerLanguageExtensions.GetLanguage(player).TwoLetterISOLanguageName, out string? userDescription)
                ? userDescription
                : (kvp.Value.Description.TryGetValue(CoreConfig.ServerLanguage, out string? serverDescription)
                    ? serverDescription
                    : kvp.Value.Description.First().Value);
                _ = menu.AddMenuOption(commandName + " " + kvp.Key + " = " + ReplaceChatColors(description), static (_, _) => { }, true);
            }
            MenuManager.OpenChatMenu(player, menu);
        }

        [ConsoleCommand("chatinfo", "ChatInfo admin commands")]
        [CommandHelper(whoCanExecute: CommandUsage.SERVER_ONLY, minArgs: 1, usage: "<command>")]
        public void CommandMapVote(CCSPlayerController player, CommandInfo command)
        {
            string subCommand = command.GetArg(1);
            switch (subCommand.ToLower(System.Globalization.CultureInfo.CurrentCulture))
            {
                case "reload":
                    Config.Reload();
                    command.ReplyToCommand(Localizer["admin.reload"]);
                    break;
                default:
                    command.ReplyToCommand(Localizer["admin.unknown_command"].Value
                        .Replace("{command}", subCommand));
                    break;
            }
        }
    }
}
