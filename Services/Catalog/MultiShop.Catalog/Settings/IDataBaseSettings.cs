using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MultiShop.Catalog.Settings
{
    public interface IDataBaseSettings
    {
        public string ConnectionString { get; set; }
        public string DataBaseName { get; set; }
        public string CategoryCollectionsName { get; set; }
        public string ProductCollectionsName { get; set; }
        public string ImageCollectionsName { get; set; }
        public string ProductDetailsCollectionsName { get; set; }
    
    }
}
