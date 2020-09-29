using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace MedicalTelegrammBot.Models.Commands
{
    internal class AnalyzesCommand : Command
    {
        internal override string Name => "Анализы";
        internal BackToStartCommand BackToStart;
        internal CommonBloodTestCommand CommonBloodTest;
        internal CommonUrineTestCommand CommonUrineTest;

        internal override async Task Execute(Message message, TelegramBotClient botClient)
        {
            var keyboardButtons = new[]
            {
                new [] // row 1
                {
                    //column 1
                    new Telegram.Bot.Types.ReplyMarkups.KeyboardButton("🔙 На главную"),
                    //column 2
                    new Telegram.Bot.Types.ReplyMarkups.KeyboardButton("🔬 Общий анализ крови")
                },
                new [] // row 2
                {
                    //column 1
                    new Telegram.Bot.Types.ReplyMarkups.KeyboardButton("🔬 Общий анализ мочи")
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

            var keyboard = new Telegram.Bot.Types.ReplyMarkups.ReplyKeyboardMarkup(keyboardButtons){ ResizeKeyboard = true};
            var inlineKeyboardSearch = new Telegram.Bot.Types.ReplyMarkups.InlineKeyboardMarkup(inlineKeyboardSearchButton);
            var chatId = message.Chat.Id;

            string botMessage = "Выберете интересующий Вас анализ: ↕️";
            string botSearchMessage = "Или воспользуйтесь кнопкой поиска по другим анализам и показателям";

            await botClient.SendTextMessageAsync(chatId, botMessage, replyToMessageId: message.MessageId, replyMarkup: keyboard);
            await botClient.SendTextMessageAsync(chatId, botSearchMessage, replyMarkup: inlineKeyboardSearch);
        }
    }
}