using System;
using System.Collections.Generic;
using System.Text;

using ECommerce.Entity.Order;

namespace ECommerce.Interfaces.IBAL
{
    public interface IOrderBAL
    {
        Task<OrderResponse> CreateAsync(
            int userId,
            OrderRequest request);

        Task<OrderResponse> GetByIdAsync(
            int userId,
            int orderId);

        Task<OrderListResponse> GetAllAsync(
            int userId);
    }
}
