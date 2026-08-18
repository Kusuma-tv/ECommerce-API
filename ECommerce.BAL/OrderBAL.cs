using System;
using System.Collections.Generic;
using System.Text;

using ECommerce.Entity.Order;
using ECommerce.Interfaces.IBAL;
using ECommerce.Interfaces.IRepository;

namespace ECommerce.BAL
{
    public class OrderBAL : IOrderBAL
    {
        private readonly IOrderRepository _orderRepository;

        public OrderBAL(
            IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<OrderResponse> CreateAsync(
            int userId,
            OrderRequest request)
        {
            if (request.CartId <= 0)
            {
                return new OrderResponse
                {
                    StatusCode = 400,
                    Message = "Invalid cart",
                    Result = null
                };
            }

            var cart = await _orderRepository
                .GetCartAsync(
                    request.CartId,
                    userId);

            if (cart == null)
            {
                return new OrderResponse
                {
                    StatusCode = 404,
                    Message = "Cart not found",
                    Result = null
                };
            }

            if (cart.CartItems == null ||
                !cart.CartItems.Any())
            {
                return new OrderResponse
                {
                    StatusCode = 400,
                    Message = "Cart is empty",
                    Result = null
                };
            }

            var order = new Order
            {
                UserId = userId,
                OrderDate = DateTime.UtcNow,
                Status = "Placed",
                TotalAmount = cart.CartItems.Sum(
                    item => item.Product.Price * item.Quantity),
                OrderItems = new List<OrderItem>()
            };

            foreach (var cartItem in cart.CartItems)
            {
                var orderItem = new OrderItem
                {
                    ProductId = cartItem.ProductId,
                    Quantity = cartItem.Quantity,
                    Price = cartItem.Product.Price,
                    Total = cartItem.Product.Price *
                            cartItem.Quantity
                };

                order.OrderItems.Add(orderItem);
            }

            var createdOrder = await _orderRepository
                .CreateAsync(
                    order,
                    cart.CartItems);

            return new OrderResponse
            {
                StatusCode = 201,
                Message = "Order created successfully",
                Result = MapToResult(createdOrder)
            };
        }

        public async Task<OrderResponse> GetByIdAsync(
            int userId,
            int orderId)
        {
            if (orderId <= 0)
            {
                return new OrderResponse
                {
                    StatusCode = 400,
                    Message = "Invalid order",
                    Result = null
                };
            }

            var order = await _orderRepository
                .GetByIdAsync(
                    orderId,
                    userId);

            if (order == null)
            {
                return new OrderResponse
                {
                    StatusCode = 404,
                    Message = "Order not found",
                    Result = null
                };
            }

            return new OrderResponse
            {
                StatusCode = 200,
                Message = "Order retrieved successfully",
                Result = MapToResult(order)
            };
        }

        public async Task<OrderListResponse> GetAllAsync(
            int userId)
        {
            var orders = await _orderRepository
                .GetAllAsync(userId);

            var result = orders
                .Select(MapToResult)
                .ToList();

            return new OrderListResponse
            {
                StatusCode = 200,
                Message = "Orders retrieved successfully",
                Result = result
            };
        }

        private OrderResult MapToResult(Order order)
        {
            return new OrderResult
            {
                OrderId = order.OrderId,
                UserId = order.UserId,
                OrderDate = order.OrderDate,
                TotalAmount = order.TotalAmount,
                Status = order.Status,
                OrderItems = order.OrderItems
                    .Select(item => new OrderItemResponse
                    {
                        OrderItemId = item.OrderItemId,
                        ProductId = item.ProductId,
                        ProductName = item.Product.Name,
                        Quantity = item.Quantity,
                        Price = item.Price,
                        Total = item.Total
                    })
                    .ToList()
            };
        }
    }
}
