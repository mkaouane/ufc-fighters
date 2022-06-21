using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace WebApplication2.Models
{
    public class Fighters
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]

        public string? Id { get; set; }

        public int? fighterId { get; set; }

        public string firstName { get; set; } = null!;

        public string lastName { get; set; } = null!;

        public string division { get; set; } = null!;

        public Boolean champion { get; set; } = false!;

        public string height { get; set; } = null!;



        [BsonElement("items")]
        [JsonPropertyName("items")]
        public List<string> fighterIds { get; set; } = null!;
    }
}
