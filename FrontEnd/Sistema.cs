using System;
using System.Net.Http;
using System.Collections.Generic;
using FrontEnd.UseCases;
using Core._03_Entidades;
using Core.Entidades;

namespace FrontEnd
{
    public class Sistema
    {
        private static Cliente ClienteLogado { get; set; }
        private readonly Cliente _clienteUC;
        private readonly ProdutoUC _produtoUC;

        public Sistema(HttpClient client)
        {
            _clienteUC = new Cliente(client);
            _produtoUC = new ProdutoUC(client);
        }

        public void IniciarSistema()
        {
            while (true)
            {
                if (ClienteLogado == null) IniciarLoginCadastro();
                else ExibirMenuPrincipal();
            }
        }

        private void IniciarLoginCadastro()
        {
            Console.WriteLine("--------- LOGIN ---------");
            Console.WriteLine("1 - Fazer login");
            Console.WriteLine("2 - Cadastrar");
            Console.WriteLine("3 - Listar Clientes");
            Console.Write("Escolha uma opção: ");
            int resposta = int.Parse(Console.ReadLine());

            if (resposta == 1) FazerLogin();
            else if (resposta == 2) CadastrarCliente();
            else if (resposta == 3) ListarClientes();
        }

        private void CadastrarCliente()
        {
            var cliente = CriarCliente();
            _clienteUC.CadastrarUsuario(cliente); // Cadastrar como cliente
            Console.WriteLine("Cliente cadastrado com sucesso.");
        }

        private void ListarClientes()
        {
            var Clientes = _clienteUC.ListarUsuarios(); // Listar clientes
            foreach (var Cliente in Cliente)
            {
                Console.WriteLine($"Nome: {Cliente.Nome}, Username: {Cliente.Username}, Email: {Cliente.Email}");
            }
        }

        private Cliente CriarCliente()
        {
            Console.WriteLine("Digite seu nome: ");
            return new Cliente
            {
                Nome = Console.ReadLine(),
                Username = Console.ReadLine(),
                Senha = Console.ReadLine(),
                Email = Console.ReadLine()
            };
        }

        private void FazerLogin()
        {
            Console.WriteLine("Digite seu username: ");
            string username = Console.ReadLine();
            Console.WriteLine("Digite sua senha: ");
            string senha = Console.ReadLine();

            var clientes = _clienteUC.FazerLogin(new ClienteLoginDTO { Username = username, Senha = senha });
            if (clientes == null)
            {
                Console.WriteLine("Cliente ou senha inválidos!!!");
                return;
            }
            ClienteLogado = clientes; // Agora o tipo é Cliente diretamente
            Console.WriteLine($"Bem-vindo, {ClienteLogado.Nome}!");
            ExibirMenuProduto();
        }

        private void ExibirMenuPrincipal()
        {
            Console.WriteLine("1 - Listar Produtos");
            Console.WriteLine("2 - Cadastrar Produto");
            Console.WriteLine("0 - Sair");

            int resposta = int.Parse(Console.ReadLine());
            switch (resposta)
            {
                case 1: ListarProdutos(); break;
                case 2: CadastrarProduto(); break;
                case 0: Environment.Exit(0); break;
            }
        }

        private void ExibirMenuProduto()
        {
            Console.WriteLine("1 - Listar Produtos");
            Console.WriteLine("2 - Adicionar Produto ao Carrinho");
            Console.WriteLine("3 - Voltar ao Menu Principal");

            int resposta = int.Parse(Console.ReadLine());
            if (resposta == 1) ListarProdutos();
            else if (resposta == 2) AdicionarProdutoAoCarrinho();
            else ExibirMenuPrincipal();
        }

        private void CadastrarProduto()
        {
            var produto = CriarProduto();
            _produtoUC.CadastrarProduto(produto);
            Console.WriteLine("Produto cadastrado com sucesso.");
        }

        private Produto CriarProduto()
        {
            Console.WriteLine("Digite o nome do produto: ");
            return new Produto
            {
                Nome = Console.ReadLine(),
                Preco = double.Parse(Console.ReadLine())
            };
        }

        private void ListarProdutos()
        {
            var produtos = _produtoUC.ListarProduto(); // A variável deve ser uma lista de produtos
            foreach (var produto in produtos)
            {
                Console.WriteLine($"Produto: {produto.Nome}, Preço: {produto.Preco}");
            }
        }

        private void AdicionarProdutoAoCarrinho()
        {
            Console.WriteLine("Digite o ID do produto que deseja adicionar ao carrinho:");
            int produtoId = int.Parse(Console.ReadLine());

            var produto = _produtoUC.ObterProdutoPorId(produtoId);
            if (produto != null)
            {
                Console.WriteLine($" foi adicionado ao carrinho.");
            }
            else
            {
                Console.WriteLine("Produto não encontrado.");
            }
        }
    }
}
