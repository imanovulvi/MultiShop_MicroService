namespace MultiShop.Catalog.DTOs.FeatureSlider
{
    public class UpdateFeatureSliderDTO
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public bool Status { get; set; } = true;
    }
}
