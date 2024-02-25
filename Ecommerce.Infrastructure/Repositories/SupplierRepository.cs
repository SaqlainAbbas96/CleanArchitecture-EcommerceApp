using Ecommerce.Core.Entities;
using Ecommerce.Core.Interfaces;
using Ecommerce.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Infrastructure.Repositories
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly AppDbContext _dbContext;
        public SupplierRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Supplier>> GetSuppliers()
        {
            return _dbContext.Suppliers.ToList();
        }

        public async Task<string> AddSupplier(Supplier model)
        {
            await _dbContext.AddAsync(model);
            _dbContext.SaveChanges();

            return "Successful";
        }

        public async Task<string> UpdateSupplier(Supplier model)
        {
            _dbContext.Update(model);
            _dbContext.SaveChanges();

            return "Successful";
        }

        public async Task<Supplier> GetSupplierById(int id)
        {
            var res = _dbContext.Suppliers.Where(x => x.supplierId == id).FirstOrDefault();
            return res;
        }

        public async Task<string> DeleteSupplier(int id)
        {
            var model = _dbContext.Suppliers.Single(x => x.supplierId == id);
            model.isActive = false;
            _dbContext.SaveChanges();

            return "Successful";
        }
    }
}
