using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace seikatsu.Models
{
    public class Properties
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = String.Empty;

        [BsonElement("images")]
        public string[] Images { get; set; } = Array.Empty<string>();

        [BsonElement("locationName")]
        public string LocationName { get; set; } = String.Empty;

        [BsonElement("locationDescription")]
        public string LocationDescription { get; set; } = String.Empty;

        [BsonElement("propertyName")]
        public string PropertyName { get; set; } = String.Empty;

        [BsonElement("geolocation")]
        public GeoLocation? GeoLocation { get; set; } = null;

    }
    
    public class GeoLocation
    {
        [BsonElement("longitude")]
        public double Longitude { get; set; }

        [BsonElement("latitude")]
        public double Latitude { get; set; }
    }

}
