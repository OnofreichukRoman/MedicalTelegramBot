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
                          new Telegram.Bot.Types.ReplyMarkups.KeyboardButton("Анализы"),
                     },
                     new[]
                     {
                          new Telegram.Bot.Types.ReplyMarkups.KeyboardButton("Первая помощь")
                     }
                },
                ResizeKeyboard = true
            };

            var chatId = message.Chat.Id;
            var userName = message.From.Username;
            string botTextAnswer = $"Здравствуйте, *{userName}*!";
            string botKeyboardMessage = "Сделайте свой выбор:";

            await botClient.SendPhotoAsync(chatId, "https://intalent.pro/sites/default/files/styles/new_photo_in_article/public/foto/article/ai-and-meds.jpg?itok=3ryePX_S", botTextAnswer, parseMode: Telegram.Bot.Types.Enums.ParseMode.Markdown);
            await botClient.SendTextMessageAsync(message.Chat.Id, botKeyboardMessage, replyMarkup: keyboard);
        }
    }
}