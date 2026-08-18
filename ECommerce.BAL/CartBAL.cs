using ECommerce.Entity.Cart;
using ECommerce.Interfaces.IBAL;
using ECommerce.Interfaces.IRepository;

namespace ECommerce.BAL
{
    public class CartBAL : ICartBAL
    {
        private readonly ICartRepository _cartRepository;

        public CartBAL(
            ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task<CartResponse> AddAsync(
    int userId,
    CartRequest request)
        {
            if (request.ProductId <= 0)
            {
                return new CartResponse
                {
                    StatusCode = 400,
                    Message = "Invalid product",
                    Result = null
                };
            }

            if (request.Quantity <= 0)
            {
                return new CartResponse
                {
                    StatusCode = 400,
                    Message = "Quantity must be greater than zero",
                    Result = null
                };
            }

            var product = await _cartRepository
                .GetProductByIdAsync(request.ProductId);

            if (product == null)
            {
                return new CartResponse
                {
                    StatusCode = 404,
                    Message = "Product not found",
                    Result = null
                };
            }

            var cart = await _cartRepository
                .GetByUserIdAsync(userId);

            if (cart == null)
            {
                cart = new Cart
                {
                    UserId = userId,
                    CartItems = new List<CartItem>()
                };

                cart = await _cartRepository
                    .CreateAsync(cart);
            }

            var existingCartItem =
                await _cartRepository.GetCartItemAsync(
                    cart.CartId,
                    request.ProductId);

            if (existingCartItem != null)
            {
                existingCartItem.Quantity += request.Quantity;

                await _cartRepository
                    .UpdateCartItemAsync(existingCartItem);
            }
            else
            {
                var cartItem = new CartItem
                {
                    CartId = cart.CartId,
                    ProductId = request.ProductId,
                    Quantity = request.Quantity
                };

                await _cartRepository
                    .CreateCartItemAsync(cartItem);
            }

            return await GetAsync(userId);
        }

        public async Task<CartResponse> GetAsync(
            int userId)
        {
            var cart = await _cartRepository
                .GetByUserIdAsync(userId);

            if (cart == null)
            {
                return new CartResponse
                {
                    StatusCode = 404,
                    Message = "Cart not found",
                    Result = null
                };
            }

            var items = cart.CartItems
                .Select(item => new CartItemResponse
                {
                    CartItemId = item.CartItemId,
                    ProductId = item.ProductId,
                    ProductName = item.Product.Name,
                    Price = item.Product.Price,
                    Quantity = item.Quantity,
                    Total = item.Product.Price * item.Quantity
                })
                .ToList();

            return new CartResponse
            {
                StatusCode = 200,
                Message = "Cart retrieved successfully",
                Result = new CartResult
                {
                    CartId = cart.CartId,
                    CartItems = items,
                    TotalAmount = items.Sum(x => x.Total)
                }
            };
        }

        public async Task<CartResponse> UpdateAsync(
            int userId,
            int cartItemId,
            CartRequest request)
        {
            if (request.Quantity <= 0)
            {
                return new CartResponse
                {
                    StatusCode = 400,
                    Message = "Quantity must be greater than zero",
                    Result = null
                };
            }

            var cart = await _cartRepository
                .GetByUserIdAsync(userId);

            if (cart == null)
            {
                return new CartResponse
                {
                    StatusCode = 404,
                    Message = "Cart not found",
                    Result = null
                };
            }

            var cartItem = await _cartRepository
                .GetCartItemByIdAsync(cartItemId);

            if (cartItem == null ||
                cartItem.CartId != cart.CartId)
            {
                return new CartResponse
                {
                    StatusCode = 404,
                    Message = "Cart item not found",
                    Result = null
                };
            }

            cartItem.Quantity = request.Quantity;

            await _cartRepository
                .UpdateCartItemAsync(cartItem);

            return await GetAsync(userId);
        }

        public async Task<CartResponse> DeleteAsync(
            int userId,
            int cartItemId)
        {
            var cart = await _cartRepository
                .GetByUserIdAsync(userId);

            if (cart == null)
            {
                return new CartResponse
                {
                    StatusCode = 404,
                    Message = "Cart not found",
                    Result = null
                };
            }

            var cartItem = await _cartRepository
                .GetCartItemByIdAsync(cartItemId);

            if (cartItem == null ||
                cartItem.CartId != cart.CartId)
            {
                return new CartResponse
                {
                    StatusCode = 404,
                    Message = "Cart item not found",
                    Result = null
                };
            }

            await _cartRepository
                .DeleteCartItemAsync(cartItemId);

            return await GetAsync(userId);
        }
    }
}