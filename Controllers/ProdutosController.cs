using MenuWebAPI.Data.Interface;
using MenuWebAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MenuWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoRepository _repo;

        public ProdutosController(IProdutoRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("GetProdutos")]
        public List<Produto> Get()
        {
            try
            {
                return _repo.GetProduto();
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public void Post(Produto produto)
        {
            try
            {
                _repo.PostProduto(produto);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut]
        public void Update(Produto produto)
        {
            try
            {
                _repo.UpdateProduto(produto);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpDelete]
        public void Delete(int id)
        {
            try
            {
                _repo.DeleteProduto(id);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
