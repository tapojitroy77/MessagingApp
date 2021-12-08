    namespace ChatApplication.Entity
{
    public class Message
    {
        public string MessageId { get; set; }
        public string MessageText { get; set; }
        public Channel Channel { get; set; }
        public User User { get; set; }
    }
}
