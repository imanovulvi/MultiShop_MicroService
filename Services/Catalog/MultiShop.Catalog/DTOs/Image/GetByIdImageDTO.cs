namespace MultiShop.Catalog.DTOs.Image
{
    public class GetByIdImageDTO
    {
        public string Id { get; set; }
        public string ImageUrl { get; set; }
        public string Base64 { get; set; }


        public string ProductId { get; set; }
    }
}
