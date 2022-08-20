using MenuWebAPI.Model;

namespace MenuWebAPI.Data.Interface
{
    public interface IProdutoRepository
    {
        List<Produto> GetProduto();
        void PostProduto(Produto produto);
        void UpdateProduto(Produto produto, int id);
        void DeleteProduto(int id);
    }
}
