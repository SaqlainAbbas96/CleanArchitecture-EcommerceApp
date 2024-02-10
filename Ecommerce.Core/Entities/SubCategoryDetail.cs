using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Core.Entities
{
    public class SubCategoryDetail
    {
        [Key]
        public int subCategoryDetailId { get; set; }
        public int subCategoryId { get; set; }
        public string? size { get; set; }
        public bool isActive { get; set; }
    }
}
