using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace MedicalTelegrammBot.Models.CallbackQueries.BloodTestIndicators
{
    internal class MonocytesCallbackQuery : CallbackQuery
    {
        internal override string Data { get; } = "Моноциты в крови";

        internal override async Task Reply(Message message, TelegramBotClient botClient)
        {
            var inlineKeyboardButtons = new Telegram.Bot.Types.ReplyMarkups.InlineKeyboardButton[][]
            {
                // row 1
                new []
                {
                    // column 1
                    Telegram.Bot.Types.ReplyMarkups.InlineKeyboardButton.WithCallbackData("<< Назад", "Показатели анализа крови")
                }
            };

            var inlineKeyboar = new Telegram.Bot.Types.ReplyMarkups.InlineKeyboardMarkup(inlineKeyboardButtons);

            string newBotMessage = "*Моноциты* – немногочисленные, но по размеру наиболее крупные иммунные клетки организма. \nЭти лейкоциты принимают участие в распознавании чужеродных веществ и обучению других лейкоцитов к их распознаванию.Могут мигрировать из крови в ткани организма.Вне кровеносного русла моноциты изменяют свою форму и преобразуются в макрофаги.Макрофаги могут активно мигрировать к очагу воспаления для того, чтобы принять участие в очищении воспаленной ткани от погибших клеток, лейкоцитов, бактерий. Благодаря такой работе макрофагов создаются все условия для восстановления поврежденных тканей.";
            var chatId = message.Chat.Id;
            var media = new InputMediaPhoto("https://raw.githubusercontent.com/OnofreichukRoman/MedicalTelegramBot/master/Images/monocytes.jpg");

            await botClient.EditMessageMediaAsync(chatId, message.MessageId, media, replyMarkup: inlineKeyboar);
            await botClient.EditMessageCaptionAsync(chatId, message.MessageId, newBotMessage, replyMarkup: inlineKeyboar, parseMode: Telegram.Bot.Types.Enums.ParseMode.Markdown);
        }
    }
}
