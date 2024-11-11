
namespace FrontEnd
{
    public class ReadProdutoDTO
    {
        public int Id { get; set; }
        public Cliente Usuario { get; set; }
        public Produto Produto { get; set; }

        public override string ToString()
        {
            return $"Usuario {Usuario.Nome} - Produto : {Produto.Nome} - Preço: {Produto.Preco}";
        }

    }
}
