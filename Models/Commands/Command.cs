using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace MedicalTelegrammBot.Models.Commands
{
    /// <summary>
    /// Defines an abstract bot command.
    /// </summary>
    internal abstract class Command
    {
        /// <summary>
        /// Gets the name of the command.
        /// </summary>
        internal abstract string Name { get; }

        /// <summary>
        /// Use this method to execute the command.
        /// </summary>
        /// <param name="message">Incoming message <see cref="Telegram.Bot.Types.Update.Message"/>.</param>
        /// <param name="botClient">An instance of the client <see cref="Bot.GetBotClientAsync()"/>.</param>
        internal abstract Task Execute(Message message, TelegramBotClient botClient);
    }
}
