using EnvironmentalProjectManagement.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EnvironmentalProjectManagement.Services
{
    public class UsuarioService
    {
        private readonly IMongoCollection<Usuario> _usuarios;

        public UsuarioService(IMongoClient client, string dbName)
        {
            var database = client.GetDatabase(dbName);
            _usuarios = database.GetCollection<Usuario>("Usuarios");
        }

        public async Task<List<Usuario>> GetUsuariosAsync()
        {
            return await _usuarios.Find(u => true).ToListAsync();
        }

        public async Task<Usuario> GetUsuarioByIdAsync(string id)
        {
            return await _usuarios.Find(u => u.Id.ToString() == id).FirstOrDefaultAsync();
        }

        public async Task<Usuario> CreateUsuarioAsync(Usuario usuario)
        {
            await _usuarios.InsertOneAsync(usuario);
            return usuario;
        }

        public async Task UpdateUsuarioAsync(string id, Usuario usuarioIn)
        {
            await _usuarios.ReplaceOneAsync(u => u.Id.ToString() == id, usuarioIn);
        }

        public async Task DeleteUsuarioAsync(string id)
        {
            await _usuarios.DeleteOneAsync(u => u.Id.ToString() == id);
        }
    }
}
