using Ecommerce.Core.DataModels;
using Ecommerce.Core.Entities;
using Ecommerce.Core.Interfaces;
using Ecommerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _dbContext;
        public ProductRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IQueryable<ProductDataModel>> GetProducts()
        {
            return _dbContext.Products
               .Join(_dbContext.SubCategories,
               p => p.subCategoryId,
               sc => sc.subCategoryId,
               (p, sc) => new { Product = p, SubCategory = sc })
               .Join(_dbContext.Suppliers,
               ps => ps.Product.supplierId,
               s => s.supplierId,
               (ps, s) => new ProductDataModel
               {
                   productId = ps.Product.productId,
                   productName = ps.Product.productName,
                   subCategoryName = ps.SubCategory.subCategoryName,
                   supplierName = s.supplierName,
                   quantity = ps.Product.quantity,
                   listingPrice = ps.Product.listingPrice,
                   retailPrice = ps.Product.retailPrice,
                   size = ps.Product.size,
                   discount = ps.Product.discount,
                   imageUrl = ps.Product.imageUrl,
                   altText = ps.Product.altText,
                   description = ps.Product.description,
                   isActive = ps.Product.isActive
               });
        }


        public async Task<string> AddProduct(Product model)
        {
            await _dbContext.AddAsync(model);
            _dbContext.SaveChanges();

            return "Successful";
        }

        public async Task<Product> GetProductById(int id)
        {
            var res = _dbContext.Products.Where(x => x.productId == id).FirstOrDefault();
            return res;
        }

        public async Task<string> UpdateProduct(Product model)
        {
            _dbContext.Update(model);
            _dbContext.SaveChanges();

            return "Successful";
        }

        public async Task<string> DeleteProduct(int id)
        {
            var model = _dbContext.Products.Single(x => x.productId == id);
            model.isActive = false;
            _dbContext.SaveChanges();

            return "Successful";
        }
    }
}
