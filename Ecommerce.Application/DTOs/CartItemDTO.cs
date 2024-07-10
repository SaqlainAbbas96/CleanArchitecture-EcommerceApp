namespace Ecommerce.Application.DTOs
{
    public class CartItemDTO
    {
        public int cartId { get; set; }
        public int productId { get; set; }
        public string productName { get; set; }
        public double retailPrice { get; set; }
        public int quantity { get; set; }
        public string imageUrl { get; set; }
        public double discount { get; set; }
        public double subTotal { get; set; }
        public double deliveryCharges { get; set; }
        public double total { get; set; }
    }
}
