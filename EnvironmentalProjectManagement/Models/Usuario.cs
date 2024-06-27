using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Microsoft.AspNetCore.Identity;

namespace EnvironmentalProjectManagement.Models
{
    public class Usuario : IdentityUser<ObjectId>
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public override ObjectId Id { get; set; }

        [BsonElement("NombreUsuario")]
        public override string? UserName { get; set; }

        [BsonElement("CorreoElectronico")]
        public override string? Email { get; set; }

        [BsonElement("Contrasena")]
        public override string? PasswordHash { get; set; }

        [BsonElement("Rol")]
        public string? Rol { get; set; } // Ej. "Líder", "Miembro"
    }
}
