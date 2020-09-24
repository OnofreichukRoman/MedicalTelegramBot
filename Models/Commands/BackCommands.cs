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

    internal class BackToAnalyzesCommand : Command
    {
        internal override string Name => "🔙 Назад к анализам";

        internal override async Task Execute(Message message, TelegramBotClient botClient)
        {
            AnalyzesCommand ac = new AnalyzesCommand();
            await ac.Execute(message, botClient);
        }
    }
}