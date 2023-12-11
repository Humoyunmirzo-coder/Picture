using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.Design;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Telegram_bot.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TelegrambotController : Controller
    {
        private TelegramBotClient client = new TelegramBotClient("6620459485:AAFkYm72MOGIft02HLqu8F5MFo0uyii4cGE");
        private readonly ITelegramBotClient _botClient;


        public TelegrambotController(ITelegramBotClient botClient)
        {
            _botClient = botClient;
        }
      

        [HttpGet]
        public async Task  GetStart()
        {
          
          
        }
        [HttpGet]
       
        public IActionResult Index()
        {
            return View();
        }
    }
}
