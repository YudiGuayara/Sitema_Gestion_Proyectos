using EnvironmentalProjectManagement.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EnvironmentalProjectManagement.Services
{
    public class TareaService
    {
        private readonly IMongoCollection<Tarea> _tareas;

        public TareaService(IMongoClient client, string dbName)
        {
            var database = client.GetDatabase(dbName);
            _tareas = database.GetCollection<Tarea>("Tareas");
        }

        public async Task<List<Tarea>> GetTareasAsync()
        {
            return await _tareas.Find(t => true).ToListAsync();
        }

        public async Task<Tarea> GetTareaByIdAsync(string id)
        {
            return await _tareas.Find(t => t.Id.ToString() == id).FirstOrDefaultAsync();
        }

        public async Task<Tarea> CreateTareaAsync(Tarea tarea)
        {
            await _tareas.InsertOneAsync(tarea);
            return tarea;
        }

        public async Task UpdateTareaAsync(string id, Tarea tareaIn)
        {
            await _tareas.ReplaceOneAsync(t => t.Id.ToString() == id, tareaIn);
        }

        public async Task DeleteTareaAsync(string id)
        {
            await _tareas.DeleteOneAsync(t => t.Id.ToString() == id);
        }
    }
}
