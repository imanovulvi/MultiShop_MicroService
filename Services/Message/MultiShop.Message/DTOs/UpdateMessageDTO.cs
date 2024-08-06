namespace MultiShop.Message.DTOs
{
    public class UpdateMessageDTO
    {
        public int Id { get; set; }
        public string SenderId { get; set; }
        public string ReceiverId { get; set; }

        public string Subject { get; set; }
        public string MessageContext { get; set; }
        public bool IRead { get; set; }
        public DateTime SendDate { get; set; }
    }
}
