using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace MedicalTelegrammBot.Models.CallbackQueries.BloodTestIndicators
{
    internal class BasophilsCallbackQuery : CallbackQuery
    {
        internal override string Data { get; } = "Базофилы в крови";

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

            string newBotMessage = "*Базофилы* являются разновидностью лейкоцитов. Они представляют собой самую малую группу и составляют не более 1 % от общей массы лейкоцитов. При обнаружении антигена(аллергена) в базофилах происходит дегрануляция. Другими словами, они выпускают свое содержимое наружу, благодаря чему блокируют аллергены, усиливают кровоток и увеличивают проницаемость сосудов. В результате создается очаг воспаления, к которому устремляются другие гранулоциты(моноциты и эозинофилы) на борьбу с чужеродным элементом. Это и есть главная функция базофилов — вовремя обнаружить и подавить аллергены, не дать им распространиться по всему организму и призвать остальных гранулоцитов к месту воспаления.  Кроме своей главной функции базофилы, благодаря наличию гепарина, участвуют в процессах свертываемости крови, препятствуют образованию тромбов в мелких сосудах легких и печени. Также они осуществляют питание тканей, поддерживают нормальный кровоток в малых кровеносных сосудах и рост новых капилляров.";
            ChatId chatId = message.Chat.Id;
            InputMediaPhoto im = new InputMediaPhoto("https://raw.githubusercontent.com/OnofreichukRoman/MedicalTelegramBot/master/Images/basophils.jpg");

            await botClient.EditMessageMediaAsync(chatId, message.MessageId, im, replyMarkup: inlineKeyboar);
            await botClient.EditMessageCaptionAsync(chatId, message.MessageId, newBotMessage, replyMarkup: inlineKeyboar, parseMode: Telegram.Bot.Types.Enums.ParseMode.Markdown);
        }
    }
}
