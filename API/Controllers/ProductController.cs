using ecommerce.Data;
using ecommerce.Interfaces;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController:ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products=await _productRepository.GetAllProductsAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductbyId([FromRoute]int id)
        {
            var product=await _productRepository.GetProductByIdAsync(id);
            return Ok(product);
        }

        [HttpPost("{id}")]

        public async Task<IActionResult> AddProduct([FromBody]EntityModel entityModel)
        {
            var id=await _productRepository.AddProductAsync(entityModel);
            return CreatedAtAction(nameof(GetProductbyId),new{id=id, controller="Product"},id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct([FromRoute]int id,[FromBody] EntityModel model)
        {
            await _productRepository.UpdateProductAsync(id,model);

            return Ok();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateProductPatch([FromRoute]int id,[FromBody] JsonPatchDocument model)
        {
            await _productRepository.UpdateProductPatchAsync(id,model);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct([FromRoute]int id)
        {
            await _productRepository.DeleteProductAsync(id);

            return Ok();
        }
        
    }
}