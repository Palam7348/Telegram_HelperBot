using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotApplication
{
    class MessageTemplatesStorage
    {
        private string botName;

        public MessageTemplatesStorage(string botName)
        {
            this.botName = botName;
        }

        public SendMessageModel SendTime(int chatId)
        {
            return new SendMessageModel { Name = botName, Message = DateTime.Now.ToString(), ChatID = chatId };
        }

        public SendMessageModel SendHelp(int chatId)
        {
            string help = "/time  -  allows to see actual time on the server \n";
            return new SendMessageModel { Name = botName, Message = help, ChatID = chatId };
        }

        public SendMessageModel SendDefault(int chatId)
        {
            string defaultText = "I don't know what do you mean \n";
            return new SendMessageModel { Name = botName, Message = defaultText, ChatID = chatId };
        }
    }
}
