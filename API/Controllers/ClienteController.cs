using AutoMapper;
using Core._01_Services.Interface;
using Core.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClienteController : ControllerBase
{
    private readonly IClienteService _service;
    private readonly IMapper _mapper;

    public ClienteController(IClienteService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpPost("adicionar")]
    public IActionResult AdicionarCliente(Cliente cliente)
    {
        _service.Adicionar(cliente);
        return Ok("Cliente adicionado com sucesso!");
    }

    [HttpPost("login")]
    public ActionResult<Cliente> FazerLogin(ClienteLoginDTO clienteLogin)
    {
        var cliente = (clienteLogin);
        return cliente != null ? Ok(cliente) : Unauthorized("Credenciais inválidas.");
    }

    [HttpGet("listar")]
    public ActionResult<List<Cliente>> ListarClientes()
    {
        return Ok(_service.Listar());
    }

    [HttpPut("editar")]
    public IActionResult EditarCliente(Cliente cliente)
    {
        _service.Editar(cliente);
        return Ok("Cliente editado com sucesso!");
    }

    [HttpDelete("deletar/{id}")]
    public IActionResult DeletarCliente(int id)
    {
        _service.Remover(id);
        return Ok("Cliente deletado com sucesso!");
    }
}
