using System.Collections.Generic;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace MedicalTelegrammBot.Models.Commands
{
    internal class BloodTestIndicatorsCommand : Command
    {
        internal override string Name => "🧾 Показатели анализа крови";
        internal List<string> IndicatorsList { get; }
        internal string CallbackData { get; }

        private readonly int _inlineKeyboardButtonRowsCount;
        private readonly int _inlineKeyboardButtonColumnsCount;

        internal BloodTestIndicatorsCommand()
        {
            IndicatorsList = new List<string>()
            {
                "Лейкоциты",
                "Нейтрофилы",
                "Лимфоциты",
                "Моноциты",
                "Эозинофилы",
                "Базофилы"
            };
            CallbackData = " в крови";
            _inlineKeyboardButtonColumnsCount = 2;
            _inlineKeyboardButtonRowsCount = (int)System.Math.Round(IndicatorsList.Count / (double)_inlineKeyboardButtonColumnsCount);
        }

        internal override async Task Execute(Message message, TelegramBotClient botClient)
        {
            var inlineKeyboarBloodTestIndicatorsButtons = new Telegram.Bot.Types.ReplyMarkups.InlineKeyboardButton[_inlineKeyboardButtonRowsCount][];

            for (int i = 0, j = 0, k = 1; i <= _inlineKeyboardButtonRowsCount; j += _inlineKeyboardButtonColumnsCount, k += _inlineKeyboardButtonColumnsCount)
            {
                // row i
                inlineKeyboarBloodTestIndicatorsButtons[i] =
                new[]
                {
                    // column 1
                    Telegram.Bot.Types.ReplyMarkups.InlineKeyboardButton.WithCallbackData(IndicatorsList[j], $"{IndicatorsList[j]}{CallbackData}"),
                    // column 2
                    Telegram.Bot.Types.ReplyMarkups.InlineKeyboardButton.WithCallbackData(IndicatorsList[k], $"{IndicatorsList[k]}{CallbackData}")
                };
            }

            var inlineKeyboarBloodTestIndicators = new Telegram.Bot.Types.ReplyMarkups.InlineKeyboardMarkup(inlineKeyboarBloodTestIndicatorsButtons);
            var chatId = message.Chat.Id;

            string botBloodTestIndicatorsMessage = "Выберете интересующий Вас показатель:";

            await botClient.SendPhotoAsync(chatId,"https://i.pinimg.com/236x/12/d8/8e/12d88e2cf8ab9dc4a744fdd9782ef9b0.jpg", botBloodTestIndicatorsMessage, replyToMessageId: message.MessageId, parseMode: Telegram.Bot.Types.Enums.ParseMode.Markdown, replyMarkup: inlineKeyboarBloodTestIndicators);
        }
    }
}