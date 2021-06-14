using System.Threading.Tasks;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _repo;
        public ProductController(IProductRepository repo)
        {
            _repo = repo;

        }
        [HttpGet]
        public async Task<IActionResult> GetListProduct()
        {
            var products = await _repo.GetProductsAsync();

            return Ok(products);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetListProduct(int id)
        {
            var product = await _repo.GetProductByIdAsync(id);

            return Ok(product);
        }
        [HttpGet("brands")]
        public async Task<IActionResult> GetListProductBrands()
        {
            var brands = await _repo.GetProductBrandsAsync();

            return Ok(brands);
        }
        [HttpGet("types")]
        public async Task<IActionResult> GetListProductTypes()
        {
            var types = await _repo.GetProductTypesAsync();

            return Ok(types);
        }
    }
}