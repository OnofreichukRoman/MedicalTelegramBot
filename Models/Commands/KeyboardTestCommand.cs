using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace MedicalTelegrammBot.Models.Commands
{
    public class KeyboardTestCommand : Command
    {
        public override string Name => @"/keyboardTest";

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
            string botTextAnswer = "#Лейкоциты \n*Лейкоциты* \nВ результатах анализа крови эти показатели указываются относительно общего содержания иммунных клеток в крови. Диагностическое значение имеет как отклонение от нормы показателя какой-либо из групп, так и повышение или понижение числа лейкоцитов в целом. При определении нормы врач в первую очередь учтет возраст пациента — показатели сильно разнятся: \n\n🔹 _Новорожденные от 1 до 3 дней — от 7 до 32 × 109 единиц на литр(Ед / л)._ \n🔹 _Возраст менее года — от 6 до 17,5 × 109 Ед / л._ \n🔹 _Возраст от 1 до 2 лет — от 6 до 17 × 109 Ед / л._ \n🔹 _Возраст от 2 до 6 лет — от 5 до 15,5 × 109 Ед / л._ \n🔹 _Возраст от 6 до 16 лет — от 4,5 до 13,5 × 109 Ед / л._ \n🔹 _Возраст от 16 до 21 - го года — от 4,5 до 11 × 109 Ед / л._ \n🔹 _Взрослые(мужчины) — от 4,2 до 9 × 109 Ед / л._ \n🔹 _Взрослые(женщины) — от 3,98 до 10,4 × 109 Ед / л._ \n🔹 _Пожилые(мужчины) — от 3,9 до 8,5 × 109 Ед / л._ \n🔹 _Пожилые(женщины) — от 3,7 до 9 × 109 Ед / л._";

            await botClient.SendPhotoAsync(chatId, "https://thepresentation.ru/img/thumbs/dc3e75780cc1225ce8dd917e1f047e49-800x.jpg", botTextAnswer, parseMode: Telegram.Bot.Types.Enums.ParseMode.Markdown);
        }
    }
}