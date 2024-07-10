using Ecommerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Services
{
    public interface IPaymentTypeService
    {
        Task<List<PaymentType>> GetPaymentTypes();
    }
}
