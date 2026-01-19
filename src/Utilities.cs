using CounterStrikeSharp.API.Modules.Utils;
using System.Reflection;

namespace ChatInfo
{
    public partial class ChatInfo
    {
        private static string ReplaceChatColors(string message)
        {
            foreach (FieldInfo field in typeof(ChatColors).GetFields(BindingFlags.Public | BindingFlags.Static))
            {
                string pattern = $"{{{field.Name}}}";
                if (message.Contains(pattern, StringComparison.OrdinalIgnoreCase))
                {
                    message = message.Replace(pattern, field.GetValue(null)?.ToString() ?? string.Empty, StringComparison.OrdinalIgnoreCase);
                }
            }
            return message;
        }
    }
}