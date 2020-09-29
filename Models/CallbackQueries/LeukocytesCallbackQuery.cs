using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace MedicalTelegrammBot.Models.CallbackQueries
{
    internal class LeukocytesCallbackQuery : CallbackQuery
    {
        internal override string Data { get; } = "Лейкоциты в крови";

        internal override async Task Reply(Message message, TelegramBotClient botClient)
        {
            var inlineKeyboarLeukocytesCallbackQueryButtons = new Telegram.Bot.Types.ReplyMarkups.InlineKeyboardButton[][]
                {
                    // row 1
                    new []
                    {
                        // column 1
                        Telegram.Bot.Types.ReplyMarkups.InlineKeyboardButton.WithCallbackData("<< Назад", "Показатели анализа крови")
                    }
                };

            var inlineKeyboarLeukocytesCallbackQuery = new Telegram.Bot.Types.ReplyMarkups.InlineKeyboardMarkup(inlineKeyboarLeukocytesCallbackQueryButtons);

            string mess = "*Лейкоциты* – клетки крови, которые образуются в костном мозге. Основная их функция – бороться с инфекцией и повреждением тканей. Выделяют пять типов лейкоцитов, которые отличаются по внешнему виду и выполняемым функциям: эозинофилы, базофилы, нейтрофилы, лимфоциты и моноциты. Они присутствуют в организме в относительно стабильных пропорциях и, хотя их численность может значительно изменяться в течение дня, в норме обычно остаются в пределах референсных значений. \nЛейкоциты образуются из стволовых клеток костного мозга и в процессе созревания проходят ряд промежуточных стадий, в ходе которых клетка и содержащееся в ней ядро уменьшаются. В кровоток должны попадать только зрелые лейкоциты.Они живут недолго, так что происходит их постоянное обновление. Производство лейкоцитов в костном мозге возрастает в ответ на любое повреждение тканей, это часть нормального воспалительного ответа. Цель воспалительного ответа – отграничение повреждения, удаление вызвавшего его причинного фактора и восстановление ткани.";
            ChatId chatId = message.Chat.Id;
            InputMediaPhoto im = new InputMediaPhoto("");

            await botClient.EditMessageCaptionAsync(chatId, message.MessageId, mess, replyMarkup: inlineKeyboarLeukocytesCallbackQuery, parseMode: Telegram.Bot.Types.Enums.ParseMode.Markdown);
            await botClient.EditMessageMediaAsync(chatId, message.MessageId, im, replyMarkup: inlineKeyboarLeukocytesCallbackQuery);
        }
    }
}
