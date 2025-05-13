using MongoDB.Bson.Serialization.Attributes;

namespace Microservice.Catalog.Api.Repositroies
{
    public class BaseEntity
    {
        [BsonElement("_id")]
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
