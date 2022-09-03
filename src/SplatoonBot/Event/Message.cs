namespace SplatoonBot.Event
{
    public class Message
    {
        public string Type { get; set; }
        public MessageData Data { get; set; }
    }

    public class MessageData
    {
        public string Text { get; set; }
    }
}
