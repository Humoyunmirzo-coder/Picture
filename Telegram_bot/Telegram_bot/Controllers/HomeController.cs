using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Mvc;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace FIrstBotASP.Controllers
{
    public class HomeController : Controller
    {
        // TelegramBotClient sinfidan obyekt hosil qilamiz
        // va unga Botfather orqali olgan tokenni
        // bog'laymiz
        private TelegramBotClient client = new TelegramBotClient("6620459485:AAFkYm72MOGIft02HLqu8F5MFo0uyii4cGE");

        // HomePage
        public string Index()
        {
            // yangi event_handler yasaldi
            client.SendPhotoAsync("810657269", Telegram.Bot.Types.InputFile.FromUri("@KXumoyunmirzo"));

            // xabar kelishini tasdiqlash
            client.StartReceiving();

            // string qaytaradi  
            return "Bot hozr ishlamoqda";
        }

        // foydalanuvchu xabar yuborganda ishlaydi
        private async void Xabar_Kelganda(object sender, MessageEventArgs e)
        {
            // foydalanuvchi idsi
            long userId = e.Message.Chat.Id;

            // kelgan xabar idsi
            int msgId = e.Message.MessageId;

            if (e.Message.Text == "/start")
            {
                // xabar yuborish
                await client.SendTextMessageAsync(userId, "Assalomu alaykum", replyToMessageId: msgId);
            }
        }
    }
}
