﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Core.Entities
{
    public class Category
    {
        [Key]
        public int categoryId { get; set; }
        public string? categoryName { get; set; }
        public string? description { get; set; }
        public string? picture { get; set; }
        public bool isActive { get; set; }
    }
}
