using DevExpress.Data.Browsing;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.PowerBI.Api.Models;
using System.Runtime.Serialization.DataContracts;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace TelegrambotAPI.Controllers
{
    [ApiController] 
    [Route("api/[controller]/ [action]")]
    public class TelegrambotController : Controller
    {

        private readonly TelegramBotClient _botClient;
        private readonly DataContext _dataContext;

        public TelegrambotController(Telegrambot telegrambot, DataContext dataContext)
        {
            _botClient = telegrambot.GetBot().Result;
            _dataContext = dataContext;
        }

        [HttpPost]
        public IActionResult Update ( Update update)
        {
            var chat = update.Message.Chat;

            var upUser = new AppUser
            {
            //    Username = chat?.Username,
            };
            return Ok(chat);
        
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
