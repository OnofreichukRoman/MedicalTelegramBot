using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace MedicalTelegrammBot.Models.Commands
{
    public class StartCommand : Command
    {
        public override string Name => @"/start";

        public override bool Contains(Message message)
        {
            if (message.Type != Telegram.Bot.Types.Enums.MessageType.Text)
            {
                return false;
            }

            return message.Text.Contains(this.Name);
        }

        public override async Task Execute(Message message, TelegramBotClient botClient)
        {
            var keyboard = new Telegram.Bot.Types.ReplyMarkups.ReplyKeyboardMarkup
            {
                Keyboard = new[]
                {
                     new[] // row 1
                     {
                          new Telegram.Bot.Types.ReplyMarkups.KeyboardButton("🔬 Анализы"),
                          new Telegram.Bot.Types.ReplyMarkups.KeyboardButton("🚑 Первая помощь")
                     }
                },
                ResizeKeyboard = true
            };

            var chatId = message.Chat.Id;
            var userName = message.From.Username;
            string botTextAnswer = $" 🏥 Добро пожаловать, *{userName}*! \nЯ помогу Вам найти информацию о самых популярных лабораторных анализах, подскажу, что делать в экстренных случаях и многое другое!";
            string botKeyboardMessage = "Выберите интересующий Вас пункт:";

            await botClient.SendPhotoAsync(chatId, "https://github.com/OnofreichukRoman/MedicalTelegrammBot/blob/master/Images/start.jpg?raw=true", botTextAnswer, parseMode: Telegram.Bot.Types.Enums.ParseMode.Markdown);
            await botClient.SendTextMessageAsync(message.Chat.Id, botKeyboardMessage, replyMarkup: keyboard);
        }
    }
}