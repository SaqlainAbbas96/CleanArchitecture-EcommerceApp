using Ecommerce.Core.DataModels;
using Ecommerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Core.Interfaces
{
    public interface ISubCategoryRepository
    {
        Task<IQueryable<SubCategoryDataModel>> GetSubCategories();
        Task<string> AddSubCategory(SubCategory model);
        Task<SubCategory> GetSubCategoryById(int id);
        Task<string> UpdateSubCategory(SubCategory model);
        Task<string> DeleteSubCategory(int id);
    }
}
