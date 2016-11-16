using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleJSON;
using System.Threading;
using System.Net;

namespace BotApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            TelegramActivity telegram = new TelegramActivity();

            telegram.Response += Telegram_Response;


            Thread updateThread = new Thread(telegram.GetUpdates);
            updateThread.IsBackground = true;
            updateThread.Start();

            for (;;) { }
        }



        private static void Telegram_Response(object sender, MessageModel e)
        {
            Console.WriteLine("{0}: {1}   chatId:{2}", e.Name, e.Message, e.ChatID);
        }

    }
}
