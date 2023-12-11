namespace Telegram_bot
{
    public class BotRespons
    {
        private async void Xabar_Kelganda(object sender, MessageEventArgs e)
        {
            if (e.Message.Text == "salom")
            {
                await client.SendTextMessageAsync(
                                chatId: e.Message.Chat.Id,
                                text: "*Assalomu alaykum*",
                                replyToMessageId: e.Message.MessageId,
                                parseMode: Telegram.Bot.Types.Enums.ParseMode.Markdown,
                                disableNotification: true
                            );
            }
        }
    }
}
