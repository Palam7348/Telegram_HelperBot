using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotApplication.Models
{
    [JsonObject]
    public class ResponseModel
    {
        [JsonProperty("ok")]
        public string Ok { get; set; }
        [JsonProperty("result")]
        public List<ResultModel> result { get; set; }
    }
}
