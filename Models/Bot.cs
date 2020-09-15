using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using MedicalTelegrammBot.Models.Commands;

namespace MedicalTelegrammBot.Models
{
    public class Bot
    {
        private static TelegramBotClient botClient;
        private static List<Command> comandsList;

        public static IReadOnlyList<Command> Commands => comandsList.AsReadOnly();

        public static async Task<TelegramBotClient> GetBotClientAsync()
        {
            if (botClient != null)
            {
                return botClient;
            }

            comandsList = new List<Command>();
            comandsList.Add(new StartCommand());
            //TODO: Add more commands

            botClient = new TelegramBotClient(AppSettings.Token);
            string hook = string.Format(AppSettings.Url, "api/message/update");
            await botClient.SetWebhookAsync(hook);
            return botClient;
        }
    }
}
