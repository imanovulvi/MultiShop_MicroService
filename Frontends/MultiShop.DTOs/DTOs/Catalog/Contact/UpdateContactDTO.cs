namespace MultiShop.DTOs.DTOs.Catalog.Contact
{
    public class UpdateContactDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public DateTime SendDate { get; set; }
        public bool IsRead { get; set; }
    }
}
