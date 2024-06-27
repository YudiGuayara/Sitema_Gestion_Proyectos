using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EnvironmentalProjectManagement.Models
{
    public class Recurso
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("Nombre")]
        public string? Nombre { get; set; }

        [BsonElement("Tipo")]
        public string? Tipo { get; set; } // Ej. "Humano", "Material", "Financiero"

        [BsonElement("Cantidad")]
        public double Cantidad { get; set; }
    }
}
