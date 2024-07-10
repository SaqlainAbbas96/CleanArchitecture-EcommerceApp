using Ecommerce.Application.DTOs;
using Ecommerce.Core.Entities;
using Microsoft.AspNetCore.Http;

namespace Ecommerce.Application.Services
{
    public interface ICartService
    {
        Task<List<CartItemDTO>> AddToCart(CartItemDTO dto);
        Task<string> DecreaseQty(int cartId, int productId, int quantity);
        Task<string> IncreaseQty(int cartId, int productId, int quantity);
        Task<string> RemoveItem(int cartId);
        Task<string> PlaceOrder(CheckoutViewModelDTO checkoutViewModel, double discount, double deliveryCharges, double totalAmount);
    }
}
