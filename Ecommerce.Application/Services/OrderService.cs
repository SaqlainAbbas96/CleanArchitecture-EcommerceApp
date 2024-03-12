using Ecommerce.Application.DTOs;

namespace Ecommerce.Application.Services
{
    public class OrderService : IOrderService
    {
        public OrderService()
        {
                
        }

        public Task<OrderViewModelDTO> GetAllOrders()
        {
            throw new NotImplementedException();
        }
    }
}
