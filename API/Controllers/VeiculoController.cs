using AutoMapper;
using Core.Entidades;
using Microsoft.AspNetCore.Mvc;
using TrabalhoFinal._01_Services;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VeiculoController : ControllerBase
    {
        private readonly VeiculoService _service;
        private readonly IMapper _mapper;

        public VeiculoController(VeiculoService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpPost("adicionar")]
        public IActionResult AdicionarVeiculo(Veiculo veiculoDTO)
        {
            _service.Adicionar(_mapper.Map<Veiculo>(veiculoDTO));
            return Ok("Veículo adicionado com sucesso!");
        }

        [HttpGet("listar")]
        public IActionResult ListarVeiculos()
        {
            return Ok(_service.Listar());
        }

        [HttpPut("editar")]
        public IActionResult EditarVeiculo(Veiculo veiculo)
        {
            _service.Editar(veiculo);
            return Ok("Veículo editado com sucesso!");
        }

        [HttpDelete("deletar/{id}")]
        public IActionResult DeletarVeiculo(int id)
        {
            _service.Remover(id);
            return Ok("Veículo deletado com sucesso!");
        }
    }
}
