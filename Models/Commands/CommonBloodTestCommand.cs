﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace MedicalTelegrammBot.Models.Commands
{
    internal class CommonBloodTestCommand : Command
    {
        internal override string Name => "🔬 Общий анализ крови";

        internal BloodTestIndicatorsCommand BloodTestIndicators { get; set; }
        internal BackToAnalyzesCommand BackToAnalyzes { get; set; }

        internal override async Task Execute(Message message, TelegramBotClient botClient)
        {
            var keyboardButtons = new[]
            {
                new [] // row 1
                {
                    //column 1
                    new Telegram.Bot.Types.ReplyMarkups.KeyboardButton("🧾 Показатели анализа крови"),
                },
                new [] // row 2
                {
                    //column 1
                    new Telegram.Bot.Types.ReplyMarkups.KeyboardButton("🔙 Назад к анализам")
                }
            };
            var inlineKeyboardSearchButton = new Telegram.Bot.Types.ReplyMarkups.InlineKeyboardButton[][]
            {
                // row 1
                new []
                {
                    // column 1
                    Telegram.Bot.Types.ReplyMarkups.InlineKeyboardButton.WithSwitchInlineQueryCurrentChat("🔍 Поиск")
                }
            };

            var keyboard = new Telegram.Bot.Types.ReplyMarkups.ReplyKeyboardMarkup(keyboardButtons) { ResizeKeyboard = true };
            var inlineKeyboardSearch = new Telegram.Bot.Types.ReplyMarkups.InlineKeyboardMarkup(inlineKeyboardSearchButton);
            var chatId = message.Chat.Id;

            string botMessage = "#Общийанализкрови #ОАК \n🔬🩸 *Общий анализ крови (ОАК)* – это наиболее доступный метод первичной оценки состояния организма, результаты которого, наряду с общим анализом мочи и биохимическим анализом крови, входят в алгоритмы диагностики большинства заболеваний. У здорового человека кровь по своему составу относительно постоянна, но   реагирует практически на любые патологические изменения в организме. Поэтому, чтобы понять, что происходит с человеком, какие исследования назначить в дальнейшем или определиться с лечением, врач, в первую очередь, всегда назначает ОАК. \nЭто исследование также используется в виде профилактического обследования даже при отсутствии каких-либо симптомов и отражает изменения состояния здоровья. Кроме того, ОАК позволяет оценить успешность проведенного лечения.";
            string botSearchMessage = "Не нашли то что искали? Воспользуйтесь кнопкой поиска по другим анализам и показателям";

            await botClient.SendPhotoAsync(chatId, "https://raw.githubusercontent.com/OnofreichukRoman/MedicalTelegrammBot/master/Images/bloodanalysis.jpg", botMessage,replyToMessageId: message.MessageId, parseMode: Telegram.Bot.Types.Enums.ParseMode.Markdown, replyMarkup: keyboard);
            await botClient.SendTextMessageAsync(chatId, botSearchMessage, replyMarkup: inlineKeyboardSearch);
        }
    }
}