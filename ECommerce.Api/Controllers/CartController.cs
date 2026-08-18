using ECommerce.Entity.Cart;
using ECommerce.Interfaces.IBAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ECommerce.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CartController : ControllerBase
    {
        private readonly ICartBAL _cartBAL;

        public CartController(ICartBAL cartBAL)
        {
            _cartBAL = cartBAL;
        }

        [HttpPost]
        public async Task<IActionResult> Add(
            CartRequest request)
        {
            var userId = int.Parse(
                User.FindFirstValue(
                    ClaimTypes.NameIdentifier));

            var response = await _cartBAL.AddAsync(
                userId,
                request);

            return StatusCode(
                response.StatusCode,
                response);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var userId = int.Parse(
                User.FindFirstValue(
                    ClaimTypes.NameIdentifier));

            var response = await _cartBAL.GetAsync(
                userId);

            return StatusCode(
                response.StatusCode,
                response);
        }

        [HttpPut("{cartItemId}")]
        public async Task<IActionResult> Update(
            int cartItemId,
            CartRequest request)
        {
            var userId = int.Parse(
                User.FindFirstValue(
                    ClaimTypes.NameIdentifier));

            var response = await _cartBAL.UpdateAsync(
                userId,
                cartItemId,
                request);

            return StatusCode(
                response.StatusCode,
                response);
        }

        [HttpDelete("{cartItemId}")]
        public async Task<IActionResult> Delete(
            int cartItemId)
        {
            var userId = int.Parse(
                User.FindFirstValue(
                    ClaimTypes.NameIdentifier));

            var response = await _cartBAL.DeleteAsync(
                userId,
                cartItemId);

            return StatusCode(
                response.StatusCode,
                response);
        }
    }
}