using MongoDB.Bson.Serialization.Attributes;

namespace Bookstore.Core
{
    public class Musicrecord
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public string Category { get; set; }

        public string Author { get; set; }
    }
}
