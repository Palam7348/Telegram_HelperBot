
using NLog;
using System;
using System.Collections.Specialized;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;
using BotApplication.Models;

namespace BotApplication
{
    public class TelegramActivity
    {
        private MessageTemplatesStorage templates;
        private System.Timers.Timer timer = new System.Timers.Timer();
        private const string token = "281838030:AAEIvhRWSxfU2SCxi_6_oKJChUnGkbY6rEg";
        private const string link = "https://api.telegram.org/bot";
        private int emptyMessageLength = 23;
        private int lastUpdateID;

        public TelegramActivity(string botName, int intervalOfUpdate)
        {
            lastUpdateID = 0;
            templates = new MessageTemplatesStorage(botName);
            timer.Elapsed += Timer_Elapsed;
            timer.Interval = intervalOfUpdate;
            timer.Start();
        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            WebClient webClient = new WebClient();
            string url = link + token + "/getupdates?offset=" + (lastUpdateID + 1);
            string response = webClient.DownloadString(url);
            if (response.Length > emptyMessageLength)
            {
                ResponseModel receivedResponse = JsonConvert.DeserializeObject<ResponseModel>(response);

                for (int i = 0; i < receivedResponse.result.Count; i++)
                {
                    lastUpdateID = receivedResponse.result[i].updateID;
                    string receivedMessage = receivedResponse.result[i].message.text;
                    int receivedChatID = receivedResponse.result[i].message.chat.id;

                    switch (receivedMessage)
                    {
                        case "/time": SendMessage(templates.SendTime(receivedChatID)); break;
                        case "/help": SendMessage(templates.SendHelp(receivedChatID)); break;
                        default: SendMessage(templates.SendDefault(receivedChatID)); break;
                    }
                }
            }
        }

        public void StopBot()
        {
            timer.Stop();
        }


        private void SendMessage(SendMessageModel model)
        {
            using (WebClient webClient = new WebClient())
            {
                NameValueCollection pars = new NameValueCollection();
                pars.Add("chat_id", model.ChatID.ToString());
                pars.Add("text", model.Message);
                webClient.UploadValues(link + token + "/sendMessage", pars);
            }
        }


    }
}
