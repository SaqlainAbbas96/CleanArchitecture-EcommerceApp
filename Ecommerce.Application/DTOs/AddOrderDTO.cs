namespace Ecommerce.Application.DTOs
{
    public record AddOrderDTO(
    // Customer Information
    string CustomerName,
    string CustomerEmail,
    string CustomerAddress,
    string CustomerPhoneNumber,

    // Product Information
    List<OrderItemDTO> OrderItems,

    // Additional Order Details
    string OrderNotes);

    public record OrderItemDTO
    {
        int ProductId { get; set; }
        string ProductName { get; set; }
        decimal UnitPrice { get; set; }
        int Quantity { get; set; }
    }

    public class CartItem
    {
        public int cartId { get; set; }
        public int productId { get; set; }
        public string productName { get; set; }
        public double retailPrice { get; set; }
        public int quantity { get; set; }
        public string imageUrl { get; set; }
        public double lineTotal { get; set; }
        public double shipping { get; set; }
        public double bill { get; set; }
    }
}
