using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Core.Entities
{
    public class SubCategory
    {
        [Key]
        public int subCategoryId { get; set; }
        public int categoryId { get; set; }
        public string? subCategoryName { get; set; }
        public string? description { get; set; }
        public bool isActive { get; set; }
    }
}
