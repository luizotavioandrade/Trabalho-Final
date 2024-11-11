using Core.Entidades;
using System.Collections.Generic;

namespace Core._01_Services.Interface
{
    public interface IProdutoService
    {
        void Adicionar(Veiculo produto);
        void Remover(int id);
        List<Veiculo> Listar();
        Veiculo BuscarPorId(int id);
        void Editar(Veiculo produto);
        void Editar();
        object? ListarProdutosPorUsuario(int usuarioId);
       
    }
}
