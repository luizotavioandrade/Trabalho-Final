using Core._01_Services.Interface;
using Core._02_Repository.Interfaces;
using Core._03_Entidades.DTO.Usuarios;
using Core.Entidades;

namespace TrabalhoFinal._01_Services;

public class ClienteService 
{
    private readonly IClienteRepository _repository;

    public ClienteService(IClienteRepository repository)
    {
        _repository = repository;
    }

    public void Adicionar(Cliente cliente) => _repository.Adicionar(cliente);

    public void Remover(int id) => _repository.Remover(id);

    public List<Cliente> Listar() => _repository.Listar();

    public Cliente BuscarPorId(int id) => _repository.BuscarPorId(id);

    public void Editar(Cliente cliente) => _repository.Editar(cliente);

    public Cliente FazerLogin(UsuarioLoginDTO usuarioLogin)
    {
        return Listar().FirstOrDefault(cliente =>
            cliente.Username == usuarioLogin.Username &&
            cliente.Senha == usuarioLogin.Senha);
    }
}
