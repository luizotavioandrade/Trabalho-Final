using Core._02_Repository.Interfaces;
using Core.Entidades;
using Dapper.Contrib.Extensions;
using System.Data.SQLite;

namespace TrabalhoFinal._02_Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly string _connectionString;

        public ClienteRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Adicionar(Cliente cliente)
        {
            using var connection = new SQLiteConnection(_connectionString);
            connection.Insert(cliente);
        }

        public void Remover(int id)
        {
            using var connection = new SQLiteConnection(_connectionString);
            var cliente = BuscarPorId(id);
            if (cliente != null)
            {
                connection.Delete(cliente);
            }
        }

        public void Editar(Cliente cliente)
        {
            using var connection = new SQLiteConnection(_connectionString);
            connection.UpdateAsync(cliente);
        }

        public List<Cliente> Listar()
        {
            using var connection = new SQLiteConnection(_connectionString);
            return connection.GetAll<Cliente>().ToList();
        }

        public Cliente BuscarPorId(int id)
        {
            using var connection = new SQLiteConnection(_connectionString);
            return connection.Get<Cliente>(id);
        }
    }
}
