using Core.Entidades;

namespace Core._03_Entidades.DTO.Produtos
{
    public class ReadProdutoDTO
    {
        public int Id { get; set; }
        public Cliente Usuario { get; set; }
        public Veiculo Produto { get; set; }

    }
}
