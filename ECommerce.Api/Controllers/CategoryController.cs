using ECommerce.Entity.Category;
using ECommerce.Interfaces.IBAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryBAL _categoryBAL;

        public CategoryController(ICategoryBAL categoryBAL)
        {
            _categoryBAL = categoryBAL;
        }


        // CREATE
        [Authorize(Roles = "Admin")]
        [HttpPost]
        
        public async Task<IActionResult> Create(
            CategoryRequest request)
        {
            var response =
                await _categoryBAL.CreateAsync(request);

            return StatusCode(
                response.StatusCode,
                response);
        }


        // GET ALL
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response =
                await _categoryBAL.GetAllAsync();

            return StatusCode(
                response.StatusCode,
                response);
        }


        // GET BY ID
        [HttpGet("{categoryId}")]
        public async Task<IActionResult> GetById(
            int categoryId)
        {
            var response =
                await _categoryBAL.GetByIdAsync(categoryId);

            return StatusCode(
                response.StatusCode,
                response);
        }


        // UPDATE
        [Authorize(Roles = "Admin")]
        [HttpPut("{categoryId}")]
        
        public async Task<IActionResult> Update(
            int categoryId,
            CategoryRequest request)
        {
            var response =
                await _categoryBAL.UpdateAsync(
                    categoryId,
                    request);

            return StatusCode(
                response.StatusCode,
                response);
        }


        // DELETE
        [Authorize(Roles = "Admin")]
        [HttpDelete("{categoryId}")]
        
        public async Task<IActionResult> Delete(
            int categoryId)
        {
            var response =
                await _categoryBAL.DeleteAsync(categoryId);

            return StatusCode(
                response.StatusCode,
                response);
        }
        [HttpGet("{categoryId}/products")]
        public async Task<IActionResult> GetCategoryWithProducts(int categoryId)
        {
            var response =
                await _categoryBAL.GetByIdWithProductsAsync(categoryId);

            return StatusCode(
                response.StatusCode,
                response);
        }
        [HttpGet("with-products")]
        public async Task<IActionResult> GetAllWithProducts()
        {
            var response =
                await _categoryBAL.GetAllWithProductsAsync();

            return StatusCode(
                response.StatusCode,
                response);
        }
    }
}