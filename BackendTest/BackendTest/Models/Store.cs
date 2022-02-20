using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BackendTest.Models
{
    public class Store
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public int NumberOfEmployees { get; set; }

        public string Logo { get; set; } = null!;

        public string Location { get; set; } = null!;
    }
}
