using Core._02_Repository.Interfaces;
using Core.Entidades;
using Dapper;
using Dapper.Contrib.Extensions;
using System.Data.SQLite;

namespace TrabalhoFinal._02_Repository
{
    public class VeiculoRepository : IProdutoRepository
    {
        private readonly string _connectionString;

        public VeiculoRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Adicionar(Veiculo veiculo)
        {
            using var connection = new SQLiteConnection(_connectionString);
            connection.Insert(veiculo);
        }

        public void Remover(int id)
        {
            using var connection = new SQLiteConnection(_connectionString);
            var veiculo = BuscarPorId(id);
            if (veiculo != null)
            {
                connection.Delete(veiculo);
            }
        }

        public void Editar(Veiculo veiculo)
        {
            using var connection = new SQLiteConnection(_connectionString);
            connection.UpdateAsync(veiculo);
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

        // Se necessário, você pode adicionar mais métodos específicos, por exemplo:
        public List<Veiculo> ListarProdutosPorUsuario(int usuarioId)
        {
            using var connection = new SQLiteConnection(_connectionString);
            return connection.Query<Veiculo>("SELECT * FROM Veiculos WHERE UsuarioId = @UsuarioId", new { UsuarioId = usuarioId }).ToList();
        }
    }
}
