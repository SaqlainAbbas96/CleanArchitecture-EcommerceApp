using Ecommerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.DTOs
{
    public record CheckoutViewModelDTO
    (   string? firstName,
        string? lastName,
        string? email,
        string? mobileNo,
        string? address,
        string? city,
        string? province,
        string? country,
        string? postalCode,
        bool isActive,
        string? notes,
        int paymentTypeId
    );
}
