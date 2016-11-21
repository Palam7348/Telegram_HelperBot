using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotApplication.Models
{
    [JsonObject]
    public class Result
    {
        [JsonProperty("update_id")]
        public int updateID { get; set; }
        [JsonProperty("message")]
        public Message message { get; set; }

    }
}
