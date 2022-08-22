using MenuWebAPI.Model;

namespace MenuWebAPI.Data.Interface
{
    public interface IProdutoRepository
    {
        List<Produto> GetProduto();
        void PostProduto(Produto produto);
        void UpdateProduto(Produto produto);
        void DeleteProduto(int id);
    }
}
