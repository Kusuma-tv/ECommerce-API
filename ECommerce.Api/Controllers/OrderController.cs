using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using ECommerce.Entity.Order;
using ECommerce.Interfaces.IBAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ECommerce.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IOrderBAL _orderBAL;

        public OrderController(IOrderBAL orderBAL)
        {
            _orderBAL = orderBAL;
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            OrderRequest request)
        {
            var userId = int.Parse(
                User.FindFirstValue(
                    ClaimTypes.NameIdentifier));

            var response = await _orderBAL.CreateAsync(
                userId,
                request);

            return StatusCode(
                response.StatusCode,
                response);
        }

        [HttpGet("{orderId}")]
        public async Task<IActionResult> GetById(
            int orderId)
        {
            var userId = int.Parse(
                User.FindFirstValue(
                    ClaimTypes.NameIdentifier));

            var response = await _orderBAL.GetByIdAsync(
                userId,
                orderId);

            return StatusCode(
                response.StatusCode,
                response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var userId = int.Parse(
                User.FindFirstValue(
                    ClaimTypes.NameIdentifier));

            var response = await _orderBAL.GetAllAsync(
                userId);

            return StatusCode(
                response.StatusCode,
                response);
        }
    }
}
