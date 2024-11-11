using Core._03_Entidades.DTO.Usuarios;
using Core.Entidades;
using System.Collections.Generic;

namespace Core._01_Services.Interface
{
    public interface IClienteService
    {
        void Adicionar(Cliente cliente);
        void Remover(int id);
        List<Cliente> Listar();
        Cliente BuscarPorId(int id);
        void Editar(Cliente cliente);
        Cliente FazerLogin(UsuarioLoginDTO usuarioLogin);
       
    }
}
