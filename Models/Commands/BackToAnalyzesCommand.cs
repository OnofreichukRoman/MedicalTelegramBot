using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace MedicalTelegrammBot.Models.Commands
{
    internal class BackToAnalyzesCommand : Command
    {
        internal override string Name => "🔙 Назад к анализам";
        internal AnalyzesCommand Analyzes { get; set; }

        internal BackToAnalyzesCommand(AnalyzesCommand analyzes)
        {
            Analyzes = analyzes;
        }

        internal override async Task Execute(Message message, TelegramBotClient botClient)
        {
            AnalyzesCommand ac = new AnalyzesCommand();
            await ac.Execute(message, botClient);
        }
    }
}