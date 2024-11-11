using Core._01_Services.Interface;
using Core._02_Repository.Interfaces;
using Core._03_Entidades.DTO.Produtos; // Supondo que você tenha um DTO para Produto
using Core.Entidades;
using TrabalhoFinal._02_Repository;

namespace TrabalhoFinal._01_Services
{
    public class ProdutoService : IProdutosService
    {
        private readonly IProdutoRepostory _repository;

        public ProdutoService(IProdutoRepostory repository)
        {
            _repository = repository;
        }

        // Métodos de Produto

        // Adicionar um novo produto
        public void Adicionar(Produto produto) => _repository.Adicionar(produto);

        // Remover um produto pelo id
        public void Remover(int id) => _repository.Remover(id);

        // Listar todos os produtos
        public List<Produto> Listar() => _repository.Listar();

        // Buscar um produto pelo ID
        public Produto BuscarPorId(int id) => _repository.BuscarPorId(id);

        // Editar um produto existente
        public void Editar(Produto produto) => _repository.Editar(produto);
    }
}
