using Core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core._02_Repository.Interfaces
{
    public interface IProdutoRepository
    {
        void Adicionar(Veiculo produto);
        void Remover(int id);
        void Editar(Veiculo produto);
        List<Veiculo> Listar();
        Veiculo BuscarPorId(int id);

    }
}
