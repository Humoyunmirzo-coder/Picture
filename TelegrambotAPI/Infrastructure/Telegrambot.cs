using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;

namespace Infrastructure
{
    public  class Telegrambot
    {
        private readonly IConfiguration _configuration;

        public Telegrambot(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task< TelegramBotClient> GetBot()
        {
            var telegram = new TelegramBotClient(_configuration["Token"]);
            var hook = $"{_configuration["Url"]} /controller/Update";
            await telegram.SetWebhookAsync(hook);
            return telegram;
        }
    }
}
