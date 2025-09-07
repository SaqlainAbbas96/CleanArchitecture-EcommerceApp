using Ecommerce.Core.Entities;
using Ecommerce.Core.Interfaces;
using Ecommerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _dbContext;
        public CategoryRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            return _dbContext.Categories.AsNoTracking().ToList();
        }

        public async Task<string> AddCategory(Category model)
        {
            await _dbContext.AddAsync(model);
            _dbContext.SaveChanges();

            return "Successful";
        }

        public async Task<string> UpdateCategory(Category model)
        {
            _dbContext.Update(model);
            _dbContext.SaveChanges();

            return "Successful";
        }

        public async Task<Category> GetCategoryById(int id)
        {
            var res = _dbContext.Categories.Where(x => x.categoryId == id).FirstOrDefault();
            return res;
        }

        public async Task<string> DeleteCategory(int id)
        {
            var model = _dbContext.Categories.Single(x => x.categoryId == id);
            model.isActive = false;
            _dbContext.SaveChanges();

            return "Successful";
        }
    }
}
