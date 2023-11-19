using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace seikatsu.Models
{
    public class Notif
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = String.Empty;

        [BsonElement("senderName")]
        public string SenderName { get; set; } = String.Empty;

        [BsonElement("receiverName")]
        public string ReceiverName { get; set; } = String.Empty;

        [BsonElement("flaggedUser")]
        public string FlaggedUser { get; set; } = String.Empty;

        [BsonElement("flag")]
        public string Flag { get; set; } = String.Empty;

        [BsonElement("message")]

        public string Message { get; set; } = String.Empty;

        [BsonElement("messageType")]

        public string MessageType { get; set; } = String.Empty;

        [BsonElement("time")]
        public string Time { get; set; } = String.Empty;

    }

}
