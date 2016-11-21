using System.Threading;

namespace BotApplication
{
    /*
     * Token - 281838030:AAEIvhRWSxfU2SCxi_6_oKJChUnGkbY6rEg
     */
    class Program
    {
        static void Main(string[] args)
        {
            TelegramActivity telegram = new TelegramActivity("281838030:AAEIvhRWSxfU2SCxi_6_oKJChUnGkbY6rEg");
            for(;;)
            {
                telegram.CheckUpdates();
                Thread.Sleep(5000);
            }
        }
    }
}
