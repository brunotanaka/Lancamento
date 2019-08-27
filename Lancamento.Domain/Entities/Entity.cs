using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Lancamento.Domain.Entities
{
    public abstract class Entity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        protected Entity()
        {
            Id = ObjectId.GenerateNewId().ToString();
        }

    }
}
