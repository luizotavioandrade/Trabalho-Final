using Core._02_Repository.Interfaces;
using Core.Entidades;

namespace TrabalhoFinal._01_Services
{
    public class VeiculoService
    {
        private readonly IProdutoRepository _repository;

        public VeiculoService(IProdutoRepository repository)
        {
            _repository = repository;
        }

        public void Adicionar(Veiculo veiculo) => _repository.Adicionar(veiculo);

        public void Remover(int id) => _repository.Remover(id);

        public List<Veiculo> Listar() => _repository.Listar();

        public Veiculo BuscarPorId(int id) => _repository.BuscarPorId(id);

        public void Editar(Veiculo veiculo) => _repository.Editar(veiculo);
    }
}
