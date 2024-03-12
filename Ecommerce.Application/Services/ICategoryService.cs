using Ecommerce.Application.DTOs;

namespace Ecommerce.Application.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryViewModelDTO>> GetAllCategories();
        Task<string> AddCategory(AddCategoryDTO dto);
        Task<UpdateCategoryDTO> GetCategoryById(int id);
        Task<string> UpdateCategory(UpdateCategoryDTO dto);
        Task<string> DeleteCategory(int id);

    }
}
