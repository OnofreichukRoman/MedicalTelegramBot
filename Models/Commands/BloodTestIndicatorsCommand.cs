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

        private readonly int _inlineKeyboardRowsCount;
        private readonly int _inlineKeyboardColumnsCount;

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
            _inlineKeyboardColumnsCount = 2;
            _inlineKeyboardRowsCount = (int)System.Math.Round(IndicatorsList.Count / (double)_inlineKeyboardColumnsCount);
        }

        internal override async Task Execute(Message message, TelegramBotClient botClient)
        {
            var inlineKeyboarButtons = new Telegram.Bot.Types.ReplyMarkups.InlineKeyboardButton[_inlineKeyboardRowsCount][];

            for (int i = 0, j = 0, k = 1; i <= _inlineKeyboardRowsCount; j += _inlineKeyboardColumnsCount, k += _inlineKeyboardColumnsCount)
            {
                // row i
                inlineKeyboarButtons[i] =
                new[]
                {
                    // column 1
                    Telegram.Bot.Types.ReplyMarkups.InlineKeyboardButton.WithCallbackData(IndicatorsList[j], $"{IndicatorsList[j]}{CallbackData}"),
                    // column 2
                    Telegram.Bot.Types.ReplyMarkups.InlineKeyboardButton.WithCallbackData(IndicatorsList[k], $"{IndicatorsList[k]}{CallbackData}")
                };
            }

            var inlineKeyboar = new Telegram.Bot.Types.ReplyMarkups.InlineKeyboardMarkup(inlineKeyboarButtons);
            var chatId = message.Chat.Id;

            string botMessage = "Выберете интересующий Вас показатель:";

            await botClient.SendPhotoAsync(chatId,"https://i.pinimg.com/236x/12/d8/8e/12d88e2cf8ab9dc4a744fdd9782ef9b0.jpg", botMessage, replyToMessageId: message.MessageId, parseMode: Telegram.Bot.Types.Enums.ParseMode.Markdown, replyMarkup: inlineKeyboar);
        }
    }
}