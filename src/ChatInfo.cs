using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Modules.Events;

namespace ChatInfo
{
    public partial class ChatInfo : BasePlugin
    {
        public override string ModuleName => "CS2 ChatInfo";
        public override string ModuleAuthor => "Kalle <kalle@kandru.de>";

        public override void Load(bool hotReload)
        {
            RegisterEventHandler<EventPlayerChat>(OnPlayerChat);
        }

        public override void Unload(bool hotReload)
        {
            DeregisterEventHandler<EventPlayerChat>(OnPlayerChat);
        }

        private HookResult OnPlayerChat(EventPlayerChat @event, GameEventInfo info)
        {
            return HookResult.Continue;
        }
    }
}
