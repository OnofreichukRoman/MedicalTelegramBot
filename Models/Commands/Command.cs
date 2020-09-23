using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace MedicalTelegrammBot.Models.Commands
{
    internal abstract class Command
    {
        internal abstract string Name { get; }

        internal abstract Task Execute(Message message, TelegramBotClient client);

        internal abstract bool Contains(Message message);
    }
}