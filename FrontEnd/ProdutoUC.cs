namespace FrontEnd
{
    internal class ProdutoUC
    {
        private HttpClient client;

        public ProdutoUC(HttpClient client)
        {
            this.client = client;
        }

        internal void CadastrarProduto(Produto produto)
        {
            throw new NotImplementedException();
        }

        internal object ListarProduto()
        {
            throw new NotImplementedException();
        }

        internal object ObterProdutoPorId(int produtoId)
        {
            throw new NotImplementedException();
        }
    }
}