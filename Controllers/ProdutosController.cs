using MenuWebAPI.Data.Interface;
using MenuWebAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

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

        [HttpPost("PostProdutos")]
        public void Post(Produto produto)
        {
            try
            {
                _repo.PostProduto(produto);
            }
            catch (Exception)
            {
                StatusCode((int)HttpStatusCode.InternalServerError, "Ocorreu um erro");
            }
        }

        [HttpPut("PutProdutos")]
        public void Update(Produto produto)
        {
            try
            {
                _repo.UpdateProduto(produto);
            }
            catch (Exception)
            {
                StatusCode((int)HttpStatusCode.InternalServerError, "Ocorreu um erro");
            }
        }

        [HttpDelete("DeleteProdutos")]
        public void Delete(int id)
        {
            try
            {
                _repo.DeleteProduto(id);
            }
            catch (Exception)
            {
                StatusCode((int)HttpStatusCode.InternalServerError, "Ocorreu um erro");
            }
        }
    }
}
