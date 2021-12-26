using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBusiness
{
    public class Category
    {
        public int CategoryId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        // navigation properties ef core
        public List<Product> Products { get; set; }
    }
}
