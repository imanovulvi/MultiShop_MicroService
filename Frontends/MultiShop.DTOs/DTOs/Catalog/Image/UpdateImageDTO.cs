namespace MultiShop.DTOs.DTOs.Catalog.Image
{
    public class UpdateImageDTO
    {
        public string Id { get; set; }
        public string ImageUrl { get; set; }
        public string Base64 { get; set; }

        public string ProductId { get; set; }
    }
}
