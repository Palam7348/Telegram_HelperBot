using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotApplication.Models
{
    [JsonObject]
    public class Message
    {
        [JsonProperty("message_id")]
        public int message_Id { get; set; }
        [JsonProperty("from")]
        public User from { get; set; }
        [JsonProperty("chat")]
        public Chat chat { get; set; }
        [JsonProperty("date")]
        public string date { get; set; }
        [JsonProperty("text")]
        public string text { get; set; }
    }
   
    
}
