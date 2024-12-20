using System.Collections.Generic;
using System.Threading.Tasks;
using API.Dtos;
using API.Errors;
using API.Helpers;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : BaseApiController
    {
        private readonly IGenericRepository<Product> _repoProduct;
        private readonly IGenericRepository<ProductBrand> _repoProductBrand;
        private readonly IGenericRepository<ProductType> _repoProductType;
        private readonly IMapper _mapper;

        public ProductController(IGenericRepository<Product> repoProduct,
        IGenericRepository<ProductBrand> repoProductBrand,
        IGenericRepository<ProductType> repoProductType,
        IMapper mapper)
        {
            _repoProduct = repoProduct;
            _repoProductBrand = repoProductBrand;
            _repoProductType = repoProductType;
            _mapper = mapper;
        }

        [CachedAtrribute(10)]
        [HttpGet]
        public async Task<ActionResult<Pagination<ProductToReturnDto>>> GetListProduct(
            [FromQuery] ProductSpecParams productSpecParams)
        {
            var spec = new ProductsWithTypesAndBrandsSpecification(productSpecParams);

            var countSpec = new ProductWithFiltersForCountSpecification(productSpecParams);

            var totalItems = await _repoProduct.CountAsync(countSpec);

            var products = await _repoProduct.ListAsync(spec);

            var data = _mapper.Map<IReadOnlyList<Product>,
            IReadOnlyList<ProductToReturnDto>>(products);

            return Ok(new Pagination<ProductToReturnDto>(productSpecParams.PageIndex,
            productSpecParams.PageSize,
            totalItems,
            data
            ));
        }

        [CachedAtrribute(10)]
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductToReturnDto>> GetProductById(int id)
        {
            var spec = new ProductsWithTypesAndBrandsSpecification(id);

            var product = await _repoProduct.GetEntityWithSpec(spec);

            if (product == null)
                return NotFound(new ApiResponse(404));

            return _mapper.Map<Product, ProductToReturnDto>(product);
        }

        [CachedAtrribute(10)]
        [HttpGet("brands")]
        public async Task<ActionResult<List<ProductBrand>>> GetListProductBrands()
        {
            var brands = await _repoProductBrand.GetListAsync();

            return Ok(brands);
        }

        [CachedAtrribute(10)]
        [HttpGet("types")]
        public async Task<ActionResult<List<ProductType>>> GetListProductTypes()
        {
            var types = await _repoProductType.GetListAsync();

            return Ok(types);
        }
    }
}