using EnvironmentalProjectManagement.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EnvironmentalProjectManagement.Services
{
    public class ProyectoService
    {
        private readonly IMongoCollection<Proyecto> _proyectos;

        public ProyectoService(IMongoClient client, string dbName)
        {
            var database = client.GetDatabase(dbName);
            _proyectos = database.GetCollection<Proyecto>("Proyectos");
        }

        public async Task<List<Proyecto>> GetProyectosAsync()
        {
            return await _proyectos.Find(p => true).ToListAsync();
        }

        public async Task<Proyecto> GetProyectoByIdAsync(string id)
        {
            return await _proyectos.Find(p => p.Id.ToString() == id).FirstOrDefaultAsync();
        }

        public async Task<Proyecto> CreateProyectoAsync(Proyecto proyecto)
        {
            await _proyectos.InsertOneAsync(proyecto);
            return proyecto;
        }

        public async Task UpdateProyectoAsync(string id, Proyecto proyectoIn)
        {
            await _proyectos.ReplaceOneAsync(p => p.Id.ToString() == id, proyectoIn);
        }

        public async Task DeleteProyectoAsync(string id)
        {
            await _proyectos.DeleteOneAsync(p => p.Id.ToString() == id);
        }
    }
}
