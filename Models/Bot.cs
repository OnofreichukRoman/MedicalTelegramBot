using MedicalTelegrammBot.Models.Commands;
using System.Collections.Generic;
using System.Threading.Tasks;
using Telegram.Bot;
using System;

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

            //Navigation
            var Start = new StartCommand() {
                Analyzes = new AnalyzesCommand()
                {
                    BackToStart = new BackToStartCommand(new StartCommand()),
                    CommonBloodTest = new CommonBloodTestCommand()
                    {
                        BloodTestIndicators = new BloodTestIndicatorsCommand(),
                        BackToAnalyzes = new BackToAnalyzesCommand(new AnalyzesCommand())
                    },
                    CommonUrineTest = new CommonUrineTestCommand()
                },
                FirstAid = new FirstAidCommand()
            };

            _comandsList = new List<Command>()
            {
                Start,
                Start.Analyzes,
                Start.Analyzes.BackToStart,
                Start.Analyzes.CommonBloodTest,
                Start.Analyzes.CommonBloodTest.BloodTestIndicators,
                Start.Analyzes.CommonBloodTest.BackToAnalyzes,
                Start.Analyzes.CommonUrineTest,
                Start.FirstAid
                //TODO: Add more commands
            };

            try
            {
                _botClient = new TelegramBotClient(AppSettings.Token);
                string hook = string.Format(AppSettings.Url, "bot/update");

                if (_botClient.GetWebhookInfoAsync().Result.Url != hook)
                {
                    await _botClient.SetWebhookAsync(hook);
                }
            }
            catch(ArgumentException ae)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine(ae.Message);
                Console.WriteLine(ae.StackTrace);
                Console.WriteLine("Press Ctrl+C to shut down.");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.BackgroundColor = ConsoleColor.Black;
            }
            return _botClient;
        }
    }
}