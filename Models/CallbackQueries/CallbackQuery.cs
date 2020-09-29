using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace MedicalTelegrammBot.Models.CallbackQueries
{
    /// <summary>
    /// Defines an abstract callback query.
    /// </summary>
    internal abstract class CallbackQuery
    {
        /// <summary>
        /// Gets the callback query data.
        /// </summary>
        internal abstract string Data { get; }

        /// <summary>
        /// Use this method to reply to a query
        /// </summary>
        /// <param name="message">Incoming callback query <see cref="Update.CallbackQuery.Message"/>.</param>
        /// <param name="botClient">An instance of the client <see cref="Bot.GetBotClientAsync()"/>.</param>
        internal abstract Task Reply(Message message, TelegramBotClient botClient);
    }
}
