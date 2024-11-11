namespace TrabalhoFinal._01_Services
{
    public interface IProdutoRepostory
    {
        void Adicionar(Produto produto);
        Produto BuscarPorId(int id);
        void Editar(Produto produto);
        List<Produto> Listar();
        void Remover(int id);
    }
}