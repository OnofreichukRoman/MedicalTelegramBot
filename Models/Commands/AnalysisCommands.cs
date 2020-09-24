using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace MedicalTelegrammBot.Models.Commands
{
    internal class AnalyzesCommand : Command
    {
        internal override string Name => "Анализы";

        internal override async Task Execute(Message message, TelegramBotClient botClient)
        {
            var keyboardCommonAnalyzesButtons = new[]
            {
                new [] // row 1
                {
                    //column 1
                    new Telegram.Bot.Types.ReplyMarkups.KeyboardButton("🔙 На главную"),
                    //column 2
                    new Telegram.Bot.Types.ReplyMarkups.KeyboardButton("🔬 Общий анализ мочи")
                },
                new [] // row 2
                {
                    //column 1
                    new Telegram.Bot.Types.ReplyMarkups.KeyboardButton("🔬 Общий анализ крови")
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

            var keyboardCommonAnalyzes = new Telegram.Bot.Types.ReplyMarkups.ReplyKeyboardMarkup(keyboardCommonAnalyzesButtons){ ResizeKeyboard = true};
            var inlineKeyboardSearch = new Telegram.Bot.Types.ReplyMarkups.InlineKeyboardMarkup(inlineKeyboardSearchButton);
            var chatId = message.Chat.Id;

            string botCommonAnalyzesMessage = "Выберете интересующий Вас анализ: ↕️";
            string botSearchAnalyzesMessage = "Или воспользуйтесь кнопкой поиска по другим анализам и показателям";

            await botClient.SendTextMessageAsync(chatId, botCommonAnalyzesMessage, replyToMessageId: message.MessageId, replyMarkup: keyboardCommonAnalyzes);
            await botClient.SendTextMessageAsync(chatId, botSearchAnalyzesMessage, replyMarkup: inlineKeyboardSearch);
        }
    }

    internal class CommonBloodTestCommand : Command
    {
        internal override string Name => "🔬 Общий анализ крови";

        internal override async Task Execute(Message message, TelegramBotClient botClient)
        {
            var keyboardCommonBloodTestButtons = new[]
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

            var keyboardCommonBloodTestAnalyzes = new Telegram.Bot.Types.ReplyMarkups.ReplyKeyboardMarkup(keyboardCommonBloodTestButtons) { ResizeKeyboard = true };
            var inlineKeyboardSearch = new Telegram.Bot.Types.ReplyMarkups.InlineKeyboardMarkup(inlineKeyboardSearchButton);
            var chatId = message.Chat.Id;

            string botCommonAnalysisOfBloodMessage = "#Общий анализ крови #ОАК \n🔬🩸 *Общий анализ крови (ОАК)* – это наиболее доступный метод первичной оценки состояния организма, результаты которого, наряду с общим анализом мочи и биохимическим анализом крови, входят в алгоритмы диагностики большинства заболеваний. У здорового человека кровь по своему составу относительно постоянна, но   реагирует практически на любые патологические изменения в организме. Поэтому, чтобы понять, что происходит с человеком, какие исследования назначить в дальнейшем или определиться с лечением, врач, в первую очередь, всегда назначает ОАК. \nЭто исследование также используется в виде профилактического обследования даже при отсутствии каких-либо симптомов и отражает изменения состояния здоровья. Кроме того, ОАК позволяет оценить успешность проведенного лечения.";
            string botSearchAnalyzesMessage = "Не нашли то что искали? Воспользуйтесь кнопкой поиска по другим анализам и показателям";

            await botClient.SendPhotoAsync(chatId, "https://raw.githubusercontent.com/OnofreichukRoman/MedicalTelegrammBot/master/Images/bloodanalysis.jpg", botCommonAnalysisOfBloodMessage,replyToMessageId: message.MessageId, parseMode: Telegram.Bot.Types.Enums.ParseMode.Markdown, replyMarkup: keyboardCommonBloodTestAnalyzes);
            await botClient.SendTextMessageAsync(chatId, botSearchAnalyzesMessage, replyMarkup: inlineKeyboardSearch);
        }
    }
}