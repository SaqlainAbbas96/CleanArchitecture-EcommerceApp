using Ecommerce.Application.DTOs;

namespace Ecommerce.Application.Services
{
    public interface ISubCategoryService
    {
        Task<IEnumerable<SubCategoryViewModelDTO>> GetAllSubCategories();
        Task<string> AddSubCategory(AddSubCategoryDTO dto);
        Task<UpdateSubCategoryDTO> GetSubCategoryById(int id);
        Task<string> UpdateSubCategory(UpdateSubCategoryDTO dto);
        Task<string> DeleteSubCategory(int id);
    }
}
