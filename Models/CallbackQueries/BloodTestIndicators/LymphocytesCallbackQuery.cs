using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace MedicalTelegrammBot.Models.CallbackQueries.BloodTestIndicators
{
    internal class LymphocytesCallbackQuery : CallbackQuery
    {
        internal override string Data { get; } = "Лимфоциты в крови";

        internal override async Task Reply(Message message, TelegramBotClient botClient)
        {
            var inlineKeyboardButtons = new Telegram.Bot.Types.ReplyMarkups.InlineKeyboardButton[][]
                {
                    // row 1
                    new []
                    {
                        // column 1
                        Telegram.Bot.Types.ReplyMarkups.InlineKeyboardButton.WithCallbackData("<< Назад", "Показатели анализа крови")
                    }
                };

            var inlineKeyboar = new Telegram.Bot.Types.ReplyMarkups.InlineKeyboardMarkup(inlineKeyboardButtons);

            string newBotMessage = "*Лимфоциты* – это один из видов лейкоцитов, особых клеток, которые циркулируют в крови человека и являются главными клетками иммунной системы. \nРазные виды лимфоцитов способны вырабатывать антитела, уничтожать чужеродные агенты(в первую очередь – вирусы, а также бактерии, грибки и простейшие) и пораженные клетки собственного организма, обуславливать развитие аллергических реакций. В детском возрасте происходит распределение и обучение в органах иммунной системы исходно недифференцированных лимфоцитов, это является основой формирования иммунитета. \nВсе лейкоциты, а значит лимфоциты в том числе, образуются в костном мозге, а затем «дозревают» в других органах в зависимости от назначения.Существуют несколько видов лимфоцитов: Т - клетки, В - клетки и NK-клетки.";
            ChatId chatId = message.Chat.Id;
            InputMediaPhoto im = new InputMediaPhoto("https://raw.githubusercontent.com/OnofreichukRoman/MedicalTelegramBot/master/Images/lymphocytes.jpg");

            await botClient.EditMessageCaptionAsync(chatId, message.MessageId, newBotMessage, replyMarkup: inlineKeyboar, parseMode: Telegram.Bot.Types.Enums.ParseMode.Markdown);
            await botClient.EditMessageMediaAsync(chatId, message.MessageId, im, replyMarkup: inlineKeyboar);
        }
    }
}
