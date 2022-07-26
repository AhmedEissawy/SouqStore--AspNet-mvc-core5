using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Souq_Store.Models
{
    public class ProductImages
    {
        public int Id { get; set; }

        public string ProductImage { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }

        
    }
}
