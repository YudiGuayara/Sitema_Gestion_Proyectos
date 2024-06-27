using EnvironmentalProjectManagement.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EnvironmentalProjectManagement.Services
{
    public class RecursoService
    {
        private readonly IMongoCollection<Recurso> _recursos;

        public RecursoService(IMongoClient client, string dbName)
        {
            var database = client.GetDatabase(dbName);
            _recursos = database.GetCollection<Recurso>("Recursos");
        }

        public async Task<List<Recurso>> GetRecursosAsync()
        {
            return await _recursos.Find(r => true).ToListAsync();
        }

        public async Task<Recurso> GetRecursoByIdAsync(string id)
        {
            return await _recursos.Find(r => r.Id.ToString() == id).FirstOrDefaultAsync();
        }

        public async Task<Recurso> CreateRecursoAsync(Recurso recurso)
        {
            await _recursos.InsertOneAsync(recurso);
            return recurso;
        }

        public async Task UpdateRecursoAsync(string id, Recurso recursoIn)
        {
            await _recursos.ReplaceOneAsync(r => r.Id.ToString() == id, recursoIn);
        }

        public async Task DeleteRecursoAsync(string id)
        {
            await _recursos.DeleteOneAsync(r => r.Id.ToString() == id);
        }
    }
}
