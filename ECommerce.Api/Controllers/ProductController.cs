using ECommerce.Entity.Product;
using ECommerce.Interfaces.IBAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IProductBAL _productBAL;

        public ProductController(
            IProductBAL productBAL)
        {
            _productBAL = productBAL;
        }


        // CREATE
        [Authorize(Roles = "Admin")]
        [HttpPost]
        
        public async Task<IActionResult> AddProduct(
            ProductRequest request)
        {
            var response =
                await _productBAL.AddAsync(request);

            return StatusCode(
                response.StatusCode,
                response);
        }


        // GET ALL
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response =
                await _productBAL.GetAllAsync();

            return StatusCode(
                response.StatusCode,
                response);
        }


        // GET BY ID
        [HttpGet("{productId}")]
        public async Task<IActionResult> GetById(
            int productId)
        {
            var response =
                await _productBAL
                    .GetByIdAsync(productId);

            return StatusCode(
                response.StatusCode,
                response);
        }


        // UPDATE
        [Authorize(Roles = "Admin")]
        [HttpPut("{productId}")]
        
        public async Task<IActionResult> Update(
            int productId,
            ProductRequest request)
        {
            var response =
                await _productBAL
                    .UpdateAsync(
                        productId,
                        request);

            return StatusCode(
                response.StatusCode,
                response);
        }


        // DELETE
        [Authorize(Roles = "Admin")]
        [HttpDelete("{productId}")]
      
        public async Task<IActionResult> Delete(
            int productId)
        {
            var response =
                await _productBAL
                    .DeleteAsync(productId);

            return StatusCode(
                response.StatusCode,
                response);
        }
    }
}