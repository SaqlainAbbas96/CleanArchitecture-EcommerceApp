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
    public class PaymentTypeRepository : IPaymentTypeRepository
    {
        private readonly AppDbContext _db;
        public PaymentTypeRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<List<PaymentType>> GetPaymentTypes()
        {
            var res = _db.PaymentTypes.ToList();
            return res;
        }
    }
}
