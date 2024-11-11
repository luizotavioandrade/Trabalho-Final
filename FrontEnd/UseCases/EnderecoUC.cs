using Core._03_Entidades;
using System.Net.Http.Json;

namespace FrontEnd.UseCases
{
    public class EnderecoService
    {
        private readonly HttpClient _client;

        public EnderecoService(HttpClient client)
        {
            _client = client;
        }

        public List<Endereco> ListarEnderecos()
        {
            return _client.GetFromJsonAsync<List<Endereco>>("Endereco/listar-endereco").Result;
        }

        public void CadastrarEndereco(Endereco endereco)
        {
            _client.PostAsJsonAsync("Endereco/adicionar-endereco", endereco).Wait();
        }
    }
}
