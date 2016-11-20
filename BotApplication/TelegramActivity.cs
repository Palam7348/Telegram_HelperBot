
using NLog;
using System;
using System.Collections.Specialized;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace BotApplication
{



    class TelegramActivity
    {
        private Logger logger = LogManager.GetCurrentClassLogger();
        private const string token = "281838030:AAEIvhRWSxfU2SCxi_6_oKJChUnGkbY6rEg";
        private const string link = "https://api.telegram.org/bot";
        private const string botName = "HelperBot";
        private int lastUpdateID;

        public delegate void ResponseDelegate(object sender, MessageModel e);
        public event ResponseDelegate Response;


        public TelegramActivity()
        {
            lastUpdateID = 0;
        }

        public void GetUpdates()
        {
            while (true)
            {

                using (WebClient webClient = new WebClient())
                {
                    string response = webClient.DownloadString(link + token + "/getupdates?offset=" + (lastUpdateID + 1));
                    if (response.Length <= 23)
                        continue;
                    var parsedResponse = (JObject)JsonConvert.DeserializeObject(response);
                    foreach (var node in parsedResponse["result"])
                    {
                        lastUpdateID = int.Parse(node["update_id"].ToString());

                        string name = node["message"]["from"]["first_name"].ToString();
                        string message = node["message"]["text"].ToString();
                        int chatID = int.Parse(node["message"]["chat"]["id"].ToString());

                        MessageModel receivedMessage = new MessageModel { Name = name, Message = message, ChatID = chatID };
                        logger.Debug(receivedMessage);
                        switch (receivedMessage.Message)
                        {
                            case "/time":
                                DateTime time = DateTime.Now;

                                string nameToSend = botName;
                                string messageToSend = time.ToString();


                                MessageModel timeMessage = new MessageModel
                                {
                                    Name = nameToSend,
                                    Message = messageToSend,
                                    ChatID = chatID
                                };

                                SendMessage(time.ToString(), receivedMessage.ChatID);
                                logger.Debug(timeMessage);
                                Response(this, receivedMessage);
                                Response(this, timeMessage);
                                break;
                            case "/help":
                                string help = "" +
                                    "/time  -  allows to see actual time on the server \n";

                                SendMessage(help, receivedMessage.ChatID);

                                MessageModel helpMessage = new MessageModel
                                {
                                    Name = botName,
                                    Message = help,
                                    ChatID = chatID
                                };

                                logger.Debug(helpMessage);

                                Response(this, receivedMessage);
                                Response(this, helpMessage);
                                break;
                            default:
                                Response(this, receivedMessage);
                                break;
                        }
                    }

                }
            }
        }


        public void SendMessage(string message, int ChatID)
        {
            using (WebClient webClient = new WebClient())
            {
                NameValueCollection pars = new NameValueCollection();
                pars.Add("chat_id", ChatID.ToString());
                pars.Add("text", message);
                webClient.UploadValues(link + token + "/sendMessage", pars);
            }
        }


    }
}
