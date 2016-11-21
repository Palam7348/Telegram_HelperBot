using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotApplication
{
    class MessageTemplatesStorage
    {
        public string SendTime()
        {
            return DateTime.Now.ToString();
        }

        public string SendHelp()
        {
            string help = "/time  -  allows to see actual time on the server \n";
            return help;
        }

        public string SendDefault()
        {
            string defaultText = "I don't know what do you mean \n";
            return defaultText;
        }
    }
}
