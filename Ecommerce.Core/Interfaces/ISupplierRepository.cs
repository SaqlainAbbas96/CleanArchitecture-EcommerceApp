using Ecommerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Core.Interfaces
{
    public interface ISupplierRepository
    {
        Task<IEnumerable<Supplier>> GetSuppliers();
        Task<string> AddSupplier(Supplier model);
        Task<Supplier> GetSupplierById(int id);
        Task<string> UpdateSupplier(Supplier model);
        Task<string> DeleteSupplier(int id);
    }
}
