 using System;
 using System.Collections.Generic;
 using System.Linq;
 using System.Threading.Tasks;
 using EnvironmentalProjectManagement.Services;
 
namespace EnvironmentalProjectManagement.Models{
    public class DatabaseSettings
    {
        public string? ConnectionString { get; set; } // La conexión predeterminada para MongoDB

        public string? DatabaseName { get; set; } // Nombre de tu base de datos MongoDB

        public string? ReportsCollectionName { get; set; }  // Nombre de la colección donde se almacenarán los documentos de informes
    }
}
