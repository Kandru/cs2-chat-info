using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Core.Attributes.Registration;
using CounterStrikeSharp.API.Modules.Commands;
using CounterStrikeSharp.API.Modules.Menu;

namespace ChatInfo
{
    public partial class ChatInfo
    {
        [ConsoleCommand("info", "shows all commands on this server")]
        [CommandHelper(whoCanExecute: CommandUsage.CLIENT_ONLY, minArgs: 0, usage: "")]
        public void CommandInfo(CCSPlayerController player, CommandInfo command)
        {
            // TODO
        }
    }
}
