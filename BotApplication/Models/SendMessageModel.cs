namespace BotApplication
{
    public class SendMessageModel
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
