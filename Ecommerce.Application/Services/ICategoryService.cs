using Ecommerce.Application.DTOs;
using Ecommerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
