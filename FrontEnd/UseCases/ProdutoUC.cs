using System.Net.Http.Json;

namespace FrontEnd.UseCases
{
    public class ProdutoService
    {
        private readonly HttpClient _client;

        public ProdutoService(HttpClient client)
        {
            _client = client;
        }

        public List<Produto> ListarProdutos()
        {
            return _client.GetFromJsonAsync<List<Produto>>("Produto/listar-produto").Result;
        }

        public void CadastrarProduto(Produto produto)
        {
            _client.PostAsJsonAsync("Produto/adicionar-produto", produto).Wait();
        }

        public Produto ObterProdutoPorId(int produtoId)
        {
            return _client.GetFromJsonAsync<Produto>($"Produto/{produtoId}").Result;
        }
    }
}
