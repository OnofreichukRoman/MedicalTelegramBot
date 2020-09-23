using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace MedicalTelegrammBot.Models.Commands
{
    internal class StartCommand : Command
    {
        internal override string Name => @"/start";

        internal override bool Contains(Message message)
        {
            if (message.Type != Telegram.Bot.Types.Enums.MessageType.Text)
            {
                return false;
            }

            return message.Text.Contains(this.Name);
        }

        internal override async Task Execute(Message message, TelegramBotClient botClient)
        {
            var keyboardButtons = new []
            {
                new [] // row 1
                {
                    //column 1
                    new Telegram.Bot.Types.ReplyMarkups.KeyboardButton("🔬 Анализы"),
                    //column 2
                    new Telegram.Bot.Types.ReplyMarkups.KeyboardButton("🚑 Первая помощь")
                }
            };

            var startKeyboard = new Telegram.Bot.Types.ReplyMarkups.ReplyKeyboardMarkup(keyboardButtons){ ResizeKeyboard = true};
            var chatId = message.Chat.Id;
            var userName = message.From.Username;

            string botTextAnswer = $" 🏥 Добро пожаловать, *{userName}*! \nЯ помогу Вам найти информацию о самых популярных лабораторных анализах, подскажу, что делать в экстренных случаях и многое другое!";
            string botStartKeyboardMessage = "Что вас интересует?";

            await botClient.SendPhotoAsync(chatId, "https://github.com/OnofreichukRoman/MedicalTelegrammBot/blob/master/Images/start.jpg?raw=true", botTextAnswer, parseMode: Telegram.Bot.Types.Enums.ParseMode.Markdown);
            await botClient.SendTextMessageAsync(message.Chat.Id, botStartKeyboardMessage, replyMarkup: startKeyboard);
        }
    }
}