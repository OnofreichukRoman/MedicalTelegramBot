using MedicalTelegrammBot.Models.Commands;
using MedicalTelegrammBot.Models.CallbackQueries.BloodTestIndicators;
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
        private static List<CallbackQuery> _callbackQueriesList;

        internal static IReadOnlyList<Command> Commands => _comandsList.AsReadOnly();
        internal static IReadOnlyList<CallbackQuery> CallbackQueries => _callbackQueriesList.AsReadOnly();

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
                        BloodTestIndicators = new BloodTestIndicatorsCommand()
                        {
                            Leukocytes = new LeukocytesCallbackQuery(),
                            Neutrophils = new NeutrophilsCallbackQuery(),
                            Lymphocytes = new LymphocytesCallbackQuery(),
                            Monocytes = new MonocytesCallbackQuery(),
                            Eosinophils = new EosinophilsCallbackQuery(),
                            Basophils = new BasophilsCallbackQuery(),
                            BackToIndicators = new BackToIndicatorsCallbackQuery()
                        },
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

            var BloodTestIndicators = Start.Analyzes.CommonBloodTest.BloodTestIndicators;

            _callbackQueriesList = new List<CallbackQuery>()
            {
                BloodTestIndicators.Leukocytes,
                BloodTestIndicators.Neutrophils,
                BloodTestIndicators.Lymphocytes,
                BloodTestIndicators.Monocytes,
                BloodTestIndicators.Eosinophils,
                BloodTestIndicators.Basophils,
                BloodTestIndicators.BackToIndicators
                //TODO: Add more callback queries
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