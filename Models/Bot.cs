using MedicalTelegrammBot.Models.Commands;
using System.Collections.Generic;
using System.Threading.Tasks;
using Telegram.Bot;

namespace MedicalTelegrammBot.Models
{
    internal static class Bot
    {
        private static TelegramBotClient _botClient;
        private static List<Command> _comandsList;

        internal static IReadOnlyList<Command> Commands => _comandsList.AsReadOnly();

        internal static async Task<TelegramBotClient> GetBotClientAsync()
        {
            if (_botClient != null)
            {
                return _botClient;
            }

            _comandsList = new List<Command>();
            _comandsList.Add(new StartCommand());
            _comandsList.Add(new AnalyzesCommand());
            //TODO: Add more commands

            _botClient = new TelegramBotClient(AppSettings.Token);
            string hook = string.Format(AppSettings.Url, "api/message/update");
            await _botClient.SetWebhookAsync(hook);
            return _botClient;
        }
    }
}