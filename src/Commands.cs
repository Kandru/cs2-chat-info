using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Core.Attributes.Registration;
using CounterStrikeSharp.API.Modules.Commands;
using CounterStrikeSharp.API.Modules.Extensions;
using CounterStrikeSharp.API.Modules.Menu;

namespace ChatInfo
{
    public partial class ChatInfo
    {
        [ConsoleCommand("info", "shows all commands on this server")]
        [CommandHelper(whoCanExecute: CommandUsage.CLIENT_ONLY, minArgs: 0, usage: "")]
        public void CommandInfo(CCSPlayerController player, CommandInfo command)
        {
            if (Config.Messages.Count == 0) return;
            // close any active menu
            MenuManager.CloseActiveMenu(player);
            // create menu to choose map
            var menu = new ChatMenu(Localizer["menu.title"]);
            foreach (var kvp in Config.Messages)
                menu.AddMenuOption(kvp.Key + " = " + kvp.Value.Description["en"],
                    (_, _) => DisplaySubCommands(player, kvp.Key),
                    kvp.Value.SubCommands.Count > 0 ? false : true);
            // open menu
            MenuManager.OpenChatMenu(player, menu);
        }

        private void DisplaySubCommands(CCSPlayerController player, string commandName)
        {
            Console.WriteLine($"DisplaySubCommands: {commandName}");
            if (player == null
                || !player.IsValid
                || !Config.Messages.ContainsKey(commandName)
                || Config.Messages[commandName].SubCommands.Count == 0) return;
            var command = Config.Messages[commandName];
            // close any active menu
            MenuManager.CloseActiveMenu(player);
            // create menu to choose map
            var menu = new ChatMenu(Localizer["menu.subtitle"].Value
                .Replace("{command}", commandName));
            foreach (var kvp in command.SubCommands)
                menu.AddMenuOption(commandName + " " + kvp.Key + " = " + kvp.Value.Description["en"], (_, _) => { }, true);
            MenuManager.OpenChatMenu(player, menu);
        }

        [ConsoleCommand("chatinfo", "ChatInfo admin commands")]
        [CommandHelper(whoCanExecute: CommandUsage.SERVER_ONLY, minArgs: 1, usage: "<command>")]
        public void CommandMapVote(CCSPlayerController player, CommandInfo command)
        {
            string subCommand = command.GetArg(1);
            switch (subCommand.ToLower())
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
