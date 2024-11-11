using System.Net.Http.Json;

namespace FrontEnd.UseCases
{
    public class ClienteService
    {
        private readonly HttpClient _client;

        public ClienteService(HttpClient client)
        {
            _client = client;
        }

        public List<Cliente> ListarUsuarios()
        {
            return _client.GetFromJsonAsync<List<Cliente>>("Usuario/listar-usuario").Result;
        }

        public void CadastrarUsuario(Cliente usuario)
        {
            _client.PostAsJsonAsync("Usuario/adicionar-usuario", usuario).Wait();
        }

        public Cliente FazerLogin(ClienteLoginDTO usuLogin)
        {
            var response = _client.PostAsJsonAsync("Usuario/fazer-login", usuLogin).Result;
            return response.Content.ReadFromJsonAsync<Cliente>().Result;
        }
    }
}
