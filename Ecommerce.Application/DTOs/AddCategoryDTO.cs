﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.DTOs
{
    public class AddCategoryDTO
    {
        public string? categoryName { get; set; }
        public string? description { get; set; }
        public bool isActive { get; set; }
    }
}
