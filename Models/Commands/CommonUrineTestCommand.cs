using System.Collections.Generic;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace MedicalTelegrammBot.Models.Commands
{
    internal class CommonUrineTestCommand : Command
    {
        internal override string Name => "🔬 Общий анализ мочи";

        internal override async Task Execute(Message message, TelegramBotClient botClient)
        {

            var chatId = message.Chat.Id;

            string botCommonUrineTestMessage = "Этот раздел в процессе создания";

            await botClient.SendTextMessageAsync(chatId, botCommonUrineTestMessage, replyToMessageId: message.MessageId, parseMode: Telegram.Bot.Types.Enums.ParseMode.Markdown);
        }
    }
}