using Core._01_Services.Interface;
using Core._02_Repository.Interfaces;
using Core._03_Entidades;

namespace Core._01_Services
{
    public class EnderecoService : IEnderecoService
    {
        private readonly IEnderecoRepository _repository;

        public EnderecoService(IEnderecoRepository repository)
        {
            _repository = repository;
        }

        public void Adicionar(Endereco endereco) => _repository.Adicionar(endereco);

        public void Remover(int id) => _repository.Remover(id);

        public List<Endereco> Listar() => _repository.Listar();

        public Endereco BuscarPorId(int id) => _repository.BuscarPorId(id);

        public void Editar(Endereco endereco) => _repository.Editar(endereco);
    }
}
