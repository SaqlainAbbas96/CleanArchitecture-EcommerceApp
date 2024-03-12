using Ecommerce.Application.DTOs;

namespace Ecommerce.Application.Services
{
    public interface IOrderService
    {
        Task<OrderViewModelDTO> GetAllOrders();
    }
}
