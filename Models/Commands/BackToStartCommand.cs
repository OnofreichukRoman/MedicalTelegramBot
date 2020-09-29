using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace MedicalTelegrammBot.Models.Commands
{
    internal class BackToStartCommand : Command
    {
        internal override string Name => "🔙 На главную";
        internal StartCommand Start;

        internal BackToStartCommand(StartCommand start)
        {
            Start = start;
        }

        internal override async Task Execute(Message message, TelegramBotClient botClient)
        {

            await Start.Execute(message, botClient);
        }
    }
}