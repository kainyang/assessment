using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BackendTest.Models
{
    public class Employee
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public string EmployeeId { get; set; } = null!;

        public string Name { get; set; } = null!;

        public int NumberOfDaysWorked { get; set; }

        public string CafeName { get; set; } = null!;
    }
}
