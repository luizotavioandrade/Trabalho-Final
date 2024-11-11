using AutoMapper;
using Core._01_Services.Interface;
using Core._03_Entidades;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnderecoConcessionariaController : ControllerBase
    {
        private readonly IEnderecoService _service;

        public EnderecoConcessionariaController(IEnderecoService service)
        {
            _service = service;
        }

        // Adiciona um endereço
        [HttpPost("adicionar")]
        public IActionResult AdicionarEndereco(Endereco endereco)
        {
            _service.Adicionar(endereco);
            return Ok("Endereço adicionado com sucesso!");
        }

        // Lista todos os endereços
        [HttpGet("listar")]
        public IActionResult ListarEnderecos()
        {
            var enderecos = _service.Listar();
            return Ok(enderecos);
        }

        // Edita um endereço
        [HttpPut("editar")]
        public IActionResult EditarEndereco(Endereco endereco)
        {
            _service.Editar(endereco);
            return Ok("Endereço editado com sucesso!");
        }

        // Deleta um endereço pelo ID
        [HttpDelete("deletar/{id}")]
        public IActionResult DeletarEndereco(int id)
        {
            _service.Remover(id);
            return Ok("Endereço deletado com sucesso!");
        }
    }
}