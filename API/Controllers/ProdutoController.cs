using AutoMapper;
using Core._01_Services.Interface;
using Core._03_Entidades.DTO.Produtos;
using Core.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _service;
        private readonly IMapper _mapper;

        public ProdutoController(IProdutoService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpPost("adicionar")]
        public IActionResult AdicionarProduto()
        {
            
            return Ok("Produto adicionado com sucesso.");
        }

        [HttpGet("listar")]
        public IActionResult ListarProdutos()
        {
            return Ok(_service.Listar());
        }

        [HttpGet("listar-do-usuario")]
        public IActionResult ListarProdutosDoUsuario([FromQuery] int usuarioId)
        {
            return Ok(_service.ListarProdutosPorUsuario(usuarioId));
        }

        [HttpPut("editar")]
        public IActionResult EditarProduto()
        {
            _service.Editar();
            return Ok("Produto editado com sucesso.");
        }

        [HttpDelete("deletar/{id}")]
        public IActionResult DeletarProduto(int id)
        {
            _service.Remover(id);
            return Ok("Produto removido com sucesso.");
        }
    }
}
