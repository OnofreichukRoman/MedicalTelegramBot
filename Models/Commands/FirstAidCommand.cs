using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace MedicalTelegrammBot.Models.Commands
{
    internal class FirstAidCommand : Command
    {
        internal override string Name => "🚑 Первая помощь";

        internal override async Task Execute(Message message, TelegramBotClient botClient)
        {

            var chatId = message.Chat.Id;

            string botFirstAidMessage = "Этот раздел в процессе создания";

            await botClient.SendTextMessageAsync(chatId, botFirstAidMessage, replyToMessageId: message.MessageId, parseMode: Telegram.Bot.Types.Enums.ParseMode.Markdown);
        }
    }
}