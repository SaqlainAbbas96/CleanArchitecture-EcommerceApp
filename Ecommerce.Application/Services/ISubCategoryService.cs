using Ecommerce.Application.DTOs;
using Ecommerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
