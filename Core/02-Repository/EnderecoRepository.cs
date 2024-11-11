using Core._02_Repository.Interfaces;
using Core._03_Entidades;
using Dapper.Contrib.Extensions;
using System.Data.SQLite;

namespace Core._02_Repository
{
    public class EnderecoRepository : IEnderecoRepository
    {
        private readonly string _connectionString;

        public EnderecoRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Adicionar(Endereco endereco)
        {
            using var connection = new SQLiteConnection(_connectionString);
            connection.Insert(endereco);
        }

        public void Remover(int id)
        {
            using var connection = new SQLiteConnection(_connectionString);
            var endereco = BuscarPorId(id);
            if (endereco != null)
            {
                connection.Delete(endereco);
            }
        }

        public void Editar(Endereco endereco)
        {
            using var connection = new SQLiteConnection(_connectionString);
            connection.UpdateAsync(endereco);
        }

        public List<Endereco> Listar()
        {
            using var connection = new SQLiteConnection(_connectionString);
            return connection.GetAll<Endereco>().ToList();
        }

        public Endereco BuscarPorId(int id)
        {
            using var connection = new SQLiteConnection(_connectionString);
            return connection.Get<Endereco>(id);
        }
    }
}
