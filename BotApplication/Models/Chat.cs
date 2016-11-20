using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotApplication.Models
{
    [JsonObject]
    public class Chat
    {
        [JsonProperty("id")]
        public int id;
        [JsonProperty("type")]
        public string type;
        public string title;
        public string username;
        [JsonProperty("first_name")]
        public string first_name;
        [JsonProperty("last_name")]
        public string last_name;

    }
}
