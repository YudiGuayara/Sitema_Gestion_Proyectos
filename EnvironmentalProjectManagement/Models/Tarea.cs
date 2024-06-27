using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace EnvironmentalProjectManagement.Models
{
    public class Tarea
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("Nombre")]
        public string? Nombre { get; set; }

        [BsonElement("Descripcion")]
        public string? Descripcion { get; set; }

        [BsonElement("FechaInicio")]
        public DateTime FechaInicio { get; set; }

        [BsonElement("FechaFin")]
        public DateTime FechaFin { get; set; }

        [BsonElement("Estado")]
        public string? Estado { get; set; } // Ej. "Pendiente", "En Progreso", "Completada"

        [BsonElement("Progreso")]
        public double Progreso { get; set; }

        [BsonElement("AsignadoA")]
        public string? AsignadoA { get; set; } // ID o nombre del usuario
    }
}
