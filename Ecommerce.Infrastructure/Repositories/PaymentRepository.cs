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
    public class PaymentRepository : IPaymentRepository
    {
        private readonly AppDbContext _db;
        public PaymentRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<string> AddPayment(Payment model)
        {
            await _db.AddAsync(model);
            _db.SaveChanges();

            return "Successful";
        }

        public async Task<string> FindPaymentType(int paymentTypeId) 
        {
            var res = _db.PaymentTypes
                .Where(x => x.paymentTypeId == paymentTypeId)
                .Select(x=>x.paymentGateway)
                .FirstOrDefault();
            return res;
        }

        public int GetLastPaymentId()
        {
            int paymentId = _db.Payments.Max(x => x.paymentId);
            return paymentId;
        }
    }
}
