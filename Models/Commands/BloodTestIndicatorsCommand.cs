using System.Collections.Generic;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using MedicalTelegrammBot.Models.CallbackQueries.BloodTestIndicators;

namespace MedicalTelegrammBot.Models.Commands
{
    internal class BloodTestIndicatorsCommand : Command
    {
        internal override string Name => "🧾 Показатели анализа крови";
        internal static List<string> IndicatorsList { get; } = new List<string>()
            {
                "Лейкоциты",
                "Нейтрофилы",
                "Лимфоциты",
                "Моноциты",
                "Эозинофилы",
                "Базофилы"
            };
        internal static string CallbackData { get; } = " в крови";
        internal static int InlineKeyboardColumnsCount { get; } = 2;
        internal static int InlineKeyboardRowsCount { get; } = (int)System.Math.Round(IndicatorsList.Count / (double)InlineKeyboardColumnsCount);

        internal LeukocytesCallbackQuery Leukocytes { get; set; }
        internal NeutrophilsCallbackQuery Neutrophils { get; set; }
        internal LymphocytesCallbackQuery Lymphocytes { get; set; }
        internal MonocytesCallbackQuery Monocytes { get; set; }
        internal EosinophilsCallbackQuery Eosinophils { get; set; }
        internal BasophilsCallbackQuery Basophils { get; set; }
        internal BackToIndicatorsCallbackQuery BackToIndicators { get; set; }

        internal override async Task Execute(Message message, TelegramBotClient botClient)
        {
            var inlineKeyboarButtons = new Telegram.Bot.Types.ReplyMarkups.InlineKeyboardButton[InlineKeyboardRowsCount][];

            for (int i = 0, j = 0, k = 1; i < InlineKeyboardRowsCount; i++, j += InlineKeyboardColumnsCount, k += InlineKeyboardColumnsCount)
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

            await botClient.SendPhotoAsync(chatId,"https://raw.githubusercontent.com/OnofreichukRoman/MedicalTelegramBot/master/Images/bloodtestindicators.jpg", botMessage, parseMode: Telegram.Bot.Types.Enums.ParseMode.Markdown, replyMarkup: inlineKeyboar);
        }
    }
}