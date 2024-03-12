using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Core.Entities
{
    public class Role
    {
        [Key]
        public int id { get; set; }
        public string rolename { get; set; }
    }
}
