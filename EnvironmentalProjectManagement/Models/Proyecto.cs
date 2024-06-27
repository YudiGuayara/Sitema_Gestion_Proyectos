using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace EnvironmentalProjectManagement.Models
{
    public class Proyecto
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

        [BsonElement("Tareas")]
        public List<Tarea> Tareas { get; set; }

        [BsonElement("Recursos")]
        public List<Recurso> Recursos { get; set; }

        [BsonElement("Progreso")]
        public double Progreso { get; set; }
    }
}
