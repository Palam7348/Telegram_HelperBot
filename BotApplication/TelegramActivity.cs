using System;
using System.Collections.Specialized;
using System.Net;
using Newtonsoft.Json;
using BotApplication.Models;

namespace BotApplication
{
    /* */
    public class TelegramActivity
    {
        private MessageTemplatesStorage templates;
        private readonly string token;
        private const string link = "https://api.telegram.org/bot";
        private int emptyMessageLength = 23;
        private int lastUpdateID;
        public int currentChatId;

        public TelegramActivity(string token)
        {
            templates = new MessageTemplatesStorage();
            this.token = token;
            lastUpdateID = 0;
            this.currentChatId = 0;
        }

        public void CheckUpdates()
        {
            try
            {
                WebClient webClient = new WebClient();
                string url = link + token + "/getupdates?offset=" + (lastUpdateID + 1);
                string response = webClient.DownloadString(url);
                if (response != null)
                {
                    if (response.Length > emptyMessageLength)
                    {
                        Response receivedResponse = JsonConvert.DeserializeObject<Response>(response);
                        if (receivedResponse != null)
                        {
                            for (int i = 0; i < receivedResponse.result.Count; i++)
                            {
                                lastUpdateID = receivedResponse.result[i].updateID;
                                string receivedMessage = receivedResponse.result[i].message.text;
                                currentChatId = receivedResponse.result[i].message.chat.id;

                                switch (receivedMessage)
                                {
                                    case "/time": SendMessage(templates.SendTime()); break;
                                    case "/help": SendMessage(templates.SendHelp()); break;
                                    default: SendMessage(templates.SendDefault()); break;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                
            }

        }


        public void SendMessage(string message)
        {
            if (message != "" && this.currentChatId != 0)
            {
                try
                {
                    WebClient webClient = new WebClient();
                    NameValueCollection pars = new NameValueCollection();
                    pars.Add("chat_id", this.currentChatId.ToString());
                    pars.Add("text", message);
                    webClient.UploadValues(link + token + "/sendMessage", pars);
                }
                catch (Exception e)
                {
                    
                }
            }
        }


    }
}
