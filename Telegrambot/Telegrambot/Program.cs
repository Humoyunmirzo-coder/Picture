
namespace Telegrambot
{
    internal class Program
    {
         static async Task Main(string[] args)
        {
            Console.WriteLine( " Xabar kiriting ");
            string  mes =  Console.ReadLine();
            Console.WriteLine(" Kimga yubotmoqchisiz");
            Console.WriteLine(" 1.Admin \n 2.Department \n 3.User ");
            string sent = Console.ReadLine();
            string Chat_token = "6837560524:AAHALUsgSi-kC7O44u6G8NQAUNBEnJOz2ts";
            long chatId = 810657269;

        
              using      HttpClient client = new ();
            client.BaseAddress = new Uri($"https://api.telegram.org/bot={Chat_token}/sendMessage?chat_id={chatId}&&text=salom");

            var  result = await client.GetAsync("");



        }
    }
}