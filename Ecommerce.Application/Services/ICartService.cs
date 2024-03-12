using Ecommerce.Application.DTOs;

namespace Ecommerce.Application.Services
{
    public interface ICartService
    {
        Task<List<CartItem>> AddToCart(CartItem dto);
    }
}
