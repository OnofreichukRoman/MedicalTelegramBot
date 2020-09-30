using MedicalTelegrammBot.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace MedicalTelegrammBot.Controllers
{
    [Route("bot/[controller]")]
    public class UpdateController : Controller
    {
        // GET bot/update
        [HttpGet]
        public string Get()
        {
            return "Method GET unavailable";
        }

        // POST bot/update
        [HttpPost]
        public async Task<OkResult> Post([FromBody] Update update)
        {
            if (update == null)
            {
                System.Console.WriteLine("Update is null");
                return Ok();
            }

            if (update.CallbackQuery?.Data != null)
            {
                var callbackQueries = Bot.CallbackQueries;
                var message = update.CallbackQuery.Message;
                var botClient = await Bot.GetBotClientAsync();

                if (botClient != null)
                {
                    foreach (var callbackQuery in callbackQueries)
                    {
                        if (update.CallbackQuery.Data == callbackQuery.Data)
                        {
                            await callbackQuery.Reply(message, botClient);
                            break;
                        }
                    }
                }
                else
                {
                    System.Console.WriteLine("botClient is null");
                }
            }

            if (update.Message?.Text != null)
            {
                var commands = Bot.Commands;
                var message = update.Message;
                var botClient = await Bot.GetBotClientAsync();

                if(botClient != null)
                {
                    foreach (var command in commands)
                    {
                        if (message.Text.Contains(command.Name))
                        {
                            await command.Execute(message, botClient);
                            break;
                        }
                    }
                }
                else
                {
                    System.Console.WriteLine("botClient is null");
                }
            }
            else if (update.Message != null && update.Message.Text == null)
            {
                System.Console.WriteLine($@"Invalid type of message {update.Message.Type}");
            }

            if(update.InlineQuery != null)
            {
                //TODO: Implement query processing.
                System.Console.WriteLine("Update type is InlineQuery");
            }
            return Ok();
        }
    }
}