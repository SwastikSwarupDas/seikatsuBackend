using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace seikatsu.Models
{
    [BsonIgnoreExtraElements]
    public class Users
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = String.Empty;

        [BsonElement("username")]
        public string Username { get; set; } = String.Empty;

        [BsonElement("password")]
        public string Password { get; set; } = String.Empty;

        [BsonElement("email")]
        public string Email { get; set; } = String.Empty;

        [BsonElement("usertype")]
        public string Usertype { get; set; } = String.Empty;

        [BsonElement("properties")]
        public string[]? Properties { get; set; }

    }
}