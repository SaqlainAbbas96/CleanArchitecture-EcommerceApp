using Ecommerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Core.Interfaces
{
    public interface IPaymentRepository
    {
        Task<string> AddPayment(Payment model);
        Task<string> FindPaymentType(int paymentTypeId);

        int GetLastPaymentId();

    }
}
