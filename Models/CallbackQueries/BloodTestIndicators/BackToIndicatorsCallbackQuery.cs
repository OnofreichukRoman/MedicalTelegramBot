using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using MedicalTelegrammBot.Models.Commands;

namespace MedicalTelegrammBot.Models.CallbackQueries.BloodTestIndicators
{
    internal class BackToIndicatorsCallbackQuery : CallbackQuery
    {
        internal override string Data { get; } = "Показатели анализа крови";

        internal override async Task Reply(Message message, TelegramBotClient botClient)
        {
            var inlineKeyboarButtons = new Telegram.Bot.Types.ReplyMarkups.InlineKeyboardButton[BloodTestIndicatorsCommand.InlineKeyboardRowsCount][];

            for (int i = 0, j = 0, k = 1; i < BloodTestIndicatorsCommand.InlineKeyboardRowsCount; i++, j += BloodTestIndicatorsCommand.InlineKeyboardColumnsCount, k += BloodTestIndicatorsCommand.InlineKeyboardColumnsCount)
            {
                // row i
                inlineKeyboarButtons[i] =
                new[]
                {
                    // column 1
                    Telegram.Bot.Types.ReplyMarkups.InlineKeyboardButton.WithCallbackData(BloodTestIndicatorsCommand.IndicatorsList[j], $"{BloodTestIndicatorsCommand.IndicatorsList[j]}{BloodTestIndicatorsCommand.CallbackData}"),
                    // column 2
                    Telegram.Bot.Types.ReplyMarkups.InlineKeyboardButton.WithCallbackData(BloodTestIndicatorsCommand.IndicatorsList[k], $"{BloodTestIndicatorsCommand.IndicatorsList[k]}{BloodTestIndicatorsCommand.CallbackData}")
                };
            }

            var inlineKeyboar = new Telegram.Bot.Types.ReplyMarkups.InlineKeyboardMarkup(inlineKeyboarButtons);
            var chatId = message.Chat.Id;

            string newBotMessage = "Выберете интересующий Вас показатель:";
            InputMediaPhoto im = new InputMediaPhoto("https://raw.githubusercontent.com/OnofreichukRoman/MedicalTelegramBot/master/Images/bloodtestindicators.jpg");

            await botClient.EditMessageMediaAsync(chatId, message.MessageId, im, replyMarkup: inlineKeyboar);
            await botClient.EditMessageCaptionAsync(chatId, message.MessageId, newBotMessage, replyMarkup: inlineKeyboar, parseMode: Telegram.Bot.Types.Enums.ParseMode.Markdown);
        }
    }
}
