using Ecommerce.Application.DTOs;

namespace Ecommerce.Application.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductViewModelDTO>> GetProducts();
        Task<string> AddProduct(AddProductDTO dto);
        Task<UpdateProductDTO> GetProductById(int id);
        Task<string> UpdateProduct(UpdateProductDTO dto);
        Task<string> DeleteProduct(int id);
    }
}
