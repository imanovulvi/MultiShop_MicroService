using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MultiShop.Catalog.Entitys
{
    public class Image
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string ImageUrl { get; set; }
        public string Base64 { get; set; }

        public string ProductId { get; set; }
        [BsonIgnore]
        public Product Product { get; set; }
    }
}
