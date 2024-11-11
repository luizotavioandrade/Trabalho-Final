using Core._02_Repository.Interfaces;
using Core.Entidades;
using Dapper.Contrib.Extensions;
using Dapper;
using System.Data.SQLite;

namespace TrabalhoFinal._02_Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly string _connectionString;

        public ProdutoRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Adicionar(Veiculo produto)
        {
            using var connection = new SQLiteConnection(_connectionString);
            connection.Insert(produto);
        }

        public void Remover(int id)
        {
            using var connection = new SQLiteConnection(_connectionString);
            var produto = BuscarPorId(id);
            if (produto != null)
            {
                connection.Delete(produto);
            }
        }

        public void Editar(Veiculo produto)
        {
            using var connection = new SQLiteConnection(_connectionString);
            connection.UpdateAsync(produto);
        }

        public List<Veiculo> Listar()
        {
            using var connection = new SQLiteConnection(_connectionString);
            return connection.GetAll<Veiculo>().ToList();
        }

        public Veiculo BuscarPorId(int id)
        {
            using var connection = new SQLiteConnection(_connectionString);
            return connection.Get<Veiculo>(id);
        }

        public List<Veiculo> ListarProdutosPorUsuario(int usuarioId)
        {
            using var connection = new SQLiteConnection(_connectionString);
            return connection.Query<Veiculo>("SELECT * FROM Veiculos WHERE UsuarioId = @UsuarioId", new { UsuarioId = usuarioId }).ToList();
        }
    }
}
