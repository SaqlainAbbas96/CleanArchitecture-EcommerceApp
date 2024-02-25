using Ecommerce.Core.DataModels;
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
    public class SubCategoryRepository : ISubCategoryRepository
    {
        private readonly AppDbContext _dbContext;

        public SubCategoryRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IQueryable<SubCategoryDataModel>> GetSubCategories()
        {
            return _dbContext.SubCategories
                .Join(_dbContext.Categories,
                sc => sc.categoryId,
                c => c.categoryId,
                (sc, c) => new SubCategoryDataModel
                {
                    subCategoryId = sc.subCategoryId,
                    subCategoryName = sc.subCategoryName!,
                    description = sc.description,
                    isActive = sc.isActive,
                    categoryId = sc.categoryId,
                    categoryName = c.categoryName!
                });
        }

        public async Task<string> AddSubCategory(SubCategory model)
        {
            await _dbContext.AddAsync(model);
            _dbContext.SaveChanges();

            return "Successful";
        }

        public async Task<string> UpdateSubCategory(SubCategory model)
        {
            _dbContext.Update(model);
            _dbContext.SaveChanges();

            return "Successful";
        }

        public async Task<SubCategory> GetSubCategoryById(int id)
        {
            var res = _dbContext.SubCategories.Where(x => x.subCategoryId == id).FirstOrDefault();
            return res;
        }

        public async Task<string> DeleteSubCategory(int id)
        {
            var model = _dbContext.SubCategories.Single(x => x.subCategoryId == id);
            model.isActive = false;
            _dbContext.SaveChanges();

            return "Successful";
        }

    }
}
