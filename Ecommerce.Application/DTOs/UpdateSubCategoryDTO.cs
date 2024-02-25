using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.DTOs
{
    public class UpdateSubCategoryDTO
    {
        public int subCategoryId { get; set; }
        public int categoryId { get; set; }
        public string? subCategoryName { get; set; }
        public string? description { get; set; }
        public bool isActive { get; set; }
    }
}
