using Core.Entidades;

namespace Core._02_Repository.Interfaces
{
    public interface IClienteRepository
    {
        void Adicionar(Cliente cliente);
        void Remover(int id);
        void Editar(Cliente cliente);
        List<Cliente> Listar();
        Cliente BuscarPorId(int id);
    }
}
