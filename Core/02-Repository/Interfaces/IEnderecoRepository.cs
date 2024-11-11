using Core._03_Entidades;
using Core.Entidades;

namespace Core._02_Repository.Interfaces
{
    public interface IEnderecoRepository
    {
        void Adicionar(Endereco endereco);
        void Remover(int id);
        void Editar(Endereco endereco);
        List<Endereco> Listar();
        Endereco BuscarPorId(int id);
    }
}
