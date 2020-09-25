using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace MedicalTelegrammBot.Models.Commands
{
    /// <summary>
    /// Defines the abstract bot command <see cref="Command" />.
    /// </summary>
    internal abstract class Command
    {
        /// <summary>
        /// Gets the command name.
        /// </summary>
        internal abstract string Name { get; }

        /// <summary>
        /// Execute the command.
        /// </summary>
        /// <param name="message">Incoming message <see cref="Update.Message"/>.</param>
        /// <param name="client">The bot client <see cref="TelegramBotClient"/>.</param>
        /// <returns>Command execution <see cref="Task"/>.</returns>
        ///
        internal abstract Task Execute(Message message, TelegramBotClient client);
    }
}
