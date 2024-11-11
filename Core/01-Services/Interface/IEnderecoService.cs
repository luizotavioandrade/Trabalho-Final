using Core._03_Entidades;
using System.Collections.Generic;

namespace Core._01_Services.Interface
{
    public interface IEnderecoService
    {
        void Adicionar(Endereco endereco);
        void Remover(int id);
        List<Endereco> Listar();
        Endereco BuscarPorId(int id);
        void Editar(Endereco endereco);
    }
}
