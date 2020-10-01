using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace MedicalTelegrammBot.Models.CallbackQueries.BloodTestIndicators
{
    internal class NeutrophilsCallbackQuery : CallbackQuery
    {
        internal override string Data { get; } = "Нейтрофилы в крови";

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

            string newBotMessage = "*Нейтрофилы* – самая многочисленная разновидность лейкоцитов. Зрелые сегментоядерные нейтрофилы у здорового взрослого человека составляют 47-72% всех лейкоцитов крови; в анализе крови определяются также незрелые палочкоядерные нейтрофилы, доля которых в норме составляет 1-6%. Повышенное содержание нейтрофилов в крови называется нейтрофилией; пониженное – нейтропенией. Нейтрофилы играют огромную роль в защите организма от инфекционных заболеваний, особенно бактериальных и грибковых. Нейтрофилы способны покидать кровяное русло и устремляться к очагу инфекции, принимая активное участие в развитии воспаления. Они также обладают способностью поглощать и разрушать чужеродные частицы – бактерии и грибы. Этот процесс называется фагоцитозом. Повышенная продукция нейтрофилов и их миграция к очагу инфекции часто являются первым ответом организма на инфекционное заболевание.";
            var chatId = message.Chat.Id;
            var media = new InputMediaPhoto("https://raw.githubusercontent.com/OnofreichukRoman/MedicalTelegramBot/master/Images/neutrophils.jpg");

            await botClient.EditMessageMediaAsync(chatId, message.MessageId, media, replyMarkup: inlineKeyboar);
            await botClient.EditMessageCaptionAsync(chatId, message.MessageId, newBotMessage, replyMarkup: inlineKeyboar, parseMode: Telegram.Bot.Types.Enums.ParseMode.Markdown);
        }
    }
}
