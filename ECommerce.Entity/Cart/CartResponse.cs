namespace ECommerce.Entity.Cart
{
    public class CartResponse
    {
        public int StatusCode { get; set; }

        public string Message { get; set; }

        public CartResult Result { get; set; }
    }
    public class CartResult
    {
        public int CartId { get; set; }

        public List<CartItemResponse> CartItems { get; set; }

        public decimal TotalAmount { get; set; }
    }
}