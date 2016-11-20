using System;
using System.Threading;
using Microsoft.Win32;
using static System.Net.Mime.MediaTypeNames;

namespace BotApplication
{
    class Program
    {
        private TelegramActivity telegram;
        private static Thread updateThread;
        

        public Program()
        {
            telegram = new TelegramActivity();
            telegram.Response += Telegram_Response;

            updateThread = new Thread(telegram.GetUpdates);
            updateThread.IsBackground = false;
            updateThread.Start();
        }


        static void Main(string[] args)
        {
            Program telegramBot = new Program();
            Console.CancelKeyPress += new ConsoleCancelEventHandler(Console_CancelKeyPress);
            //AutoLoadForm form = new AutoLoadForm();
            //form.ShowDialog();
        }

        private static void Telegram_Response(object sender, MessageModel e)
        {
            Console.WriteLine("{0}: {1}   ", e.Name, e.Message);
        }


        private static void Console_CancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {
            updateThread.Abort();
        }


        

    }
}
