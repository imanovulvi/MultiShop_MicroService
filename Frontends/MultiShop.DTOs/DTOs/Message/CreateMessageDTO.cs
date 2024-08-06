namespace MultiShop.DTOs.DTOs.Message
{
    public class CreateMessageDTO
    {
        public string SenderId { get; set; }
        public string ReceiverId { get; set; }

        public string Subject { get; set; }
        public string MessageContext { get; set; }
        public bool IRead { get; set; }
        public DateTime SendDate { get; set; }
    }
}
