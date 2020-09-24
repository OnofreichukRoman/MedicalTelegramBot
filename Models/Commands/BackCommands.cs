using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace MedicalTelegrammBot.Models.Commands
{
    internal class BackToStartCommand : Command
    {
        internal override string Name => "🔙 На главную";

        internal override async Task Execute(Message message, TelegramBotClient botClient)
        {
            StartCommand st = new StartCommand();
            await st.Execute(message, botClient);
        }
    }
}