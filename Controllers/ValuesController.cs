using MedicalTelegrammBot.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace MedicalTelegrammBot.Controllers
{
    [Route("api/message/update")]
    public class MessageController : Controller
    {
        // GET api/values
        [HttpGet]
        public string Get()
        {
            return "Method GET unavailable";
        }

        // POST api/values
        [HttpPost]
        public async Task<OkResult> Post([FromBody] Update update)
        {
            if (update == null || update.Message == null || update.InlineQuery == null)
            {
                System.Console.WriteLine("UpdateNullPointerExeption");
                return Ok();
            }

            try
            {
                var commands = Bot.Commands;
                var message = update.Message;
                var botClient = await Bot.GetBotClientAsync();

                foreach (var command in commands)
                {
                    if (command.Contains(message))
                    {
                        await command.Execute(message, botClient);
                        break;
                    }
                }
                return Ok();
            }
            catch(System.Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                return Ok();
            }
        }
    }
}