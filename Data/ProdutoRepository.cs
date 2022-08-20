using Dapper;
using MenuWebAPI.Data.Interface;
using MenuWebAPI.Model;
using System.Data;

namespace MenuWebAPI.Data
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly DbSession _dbSession;

        public ProdutoRepository(DbSession dbSession)
        {
            _dbSession = dbSession;
        }


        public List<Produto> GetProduto()
        {
            List<Produto> produtos = new List<Produto>();
            using (IDbConnection connection = _dbSession.Connection)
            {
                string sql = "SELECT pro_id as Id, pro_nome as Nome, pro_tipo as Tipo, pro_preco as Preco FROM produto;";

                produtos = connection.Query<Produto>(sql).ToList();
            }
            return produtos;
        }

        public void PostProduto(Produto produto)
        {
            using (IDbConnection connection = _dbSession.Connection)
            {
                string sql = @"insert into produto (pro_nome, 
                pro_tipo, pro_preco) values (@nome, @tipo, @preco);";

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@nome", produto.Nome);
                parameters.Add("@tipo", produto.Tipo);
                parameters.Add("@preco", produto.Preco);

                connection.Execute(sql, parameters);
            }

        }

        public void UpdateProduto(Produto produto, int id)
        {
            using (IDbConnection connection = _dbSession.Connection)
            {
                string sql = @"update produto set pro_nome = @nome, pro_tipo = @tipo, pro_preco = @preco 
                                where pro_id = @id;";

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@id", id);
                parameters.Add("@nome", produto.Nome);
                parameters.Add("@tipo", produto.Tipo);
                parameters.Add("@preco", produto.Preco);

                connection.Execute(sql, parameters);
            }
        }

        public void DeleteProduto(int id)
        {
            using (IDbConnection connection = _dbSession.Connection)
            {
                string sql = "DELETE FROM produto WHERE pro_id = @id";

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@id", id);

                connection.Execute(sql, parameters);
            }
        }
    }
}
