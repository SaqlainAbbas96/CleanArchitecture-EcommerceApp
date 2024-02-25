using Ecommerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Core.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetCategories();
        Task<string> AddCategory(Category model);
        Task<Category> GetCategoryById(int id);
        Task<string> UpdateCategory(Category model);
        Task<string> DeleteCategory(int id);
    }
}
