using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace MedicalTelegrammBot.Models.CallbackQueries.BloodTestIndicators
{
    internal class EosinophilsCallbackQuery : CallbackQuery
    {
        internal override string Data { get; } = "Эозинофилы в крови";

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

            string newBotMessage = "*Эозинофилы* — один из видов лейкоцитов, клеток иммунной системы, защищающих человеческий организм от паразитов и участвующих в развитии аллергических реакций. \nЭозинофилия крови — это состояние, характеризующееся абсолютным или относительным повышением числа эозинофилов. \nАнализ крови на эозинофилы свидетельствует о наличии различных заболеваний и помогает своевременно начать их лечение.";
            var chatId = message.Chat.Id;
            var media = new InputMediaPhoto("https://raw.githubusercontent.com/OnofreichukRoman/MedicalTelegramBot/master/Images/eosinophils.jpg");

            await botClient.EditMessageMediaAsync(chatId, message.MessageId, media, replyMarkup: inlineKeyboar);
            await botClient.EditMessageCaptionAsync(chatId, message.MessageId, newBotMessage, replyMarkup: inlineKeyboar, parseMode: Telegram.Bot.Types.Enums.ParseMode.Markdown);
        }
    }
}
