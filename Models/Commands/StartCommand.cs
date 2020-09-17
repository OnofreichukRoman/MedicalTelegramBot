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
            var chatId = message.Chat.Id;
            string botTextAnswer = $"[This is picture](https://thepresentation.ru/img/thumbs/dc3e75780cc1225ce8dd917e1f047e49-800x.jpg) *Привет*, если ты это видишь значит Рома таки все сделал. Твой chatId: {chatId}. Можешь использовать новую команду /keyboardTest ";

            await botClient.SendTextMessageAsync(chatId, botTextAnswer, parseMode: Telegram.Bot.Types.Enums.ParseMode.Markdown);
        }
    }
}