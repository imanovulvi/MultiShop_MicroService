namespace MultiShop.Catalog.Settings
{
    public class DataBaseSettings:IDataBaseSettings
    {
        public string ConnectionString { get; set; }
        public string DataBaseName { get; set; }
        public string CategoryCollectionsName { get; set; }
        public string ProductCollectionsName { get; set; }
        public string ImageCollectionsName { get; set; }
        public string ProductDetailsCollectionsName { get; set; }
        public string FeatureSlidersCollectionsName { get; set; }
        public string SpecialOfferCollectionsName { get; set; }
        public string FeaturedCollectionsName { get; set; }
        public string DiscountOfferCollectionsName { get; set; }
        public string BrandCollectionsName { get; set; }
        public string AboutCollectionsName { get; set; }




    }
}
