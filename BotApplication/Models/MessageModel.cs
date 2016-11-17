using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotApplication
{
    public class MessageModel : EventArgs
    {
        public string Name { get; set; }
        public string Message { get; set; }
        public int ChatID { get; set; }

        public override string ToString()
        {
            return "Username: " + this.Name + ",Message: " + this.Message + ", ChatID: " + this.ChatID;
        }
    }
}
