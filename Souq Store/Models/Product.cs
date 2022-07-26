using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Souq_Store.Models
{
    public class Product
    {

        public Product()
        {
            ProductImages = new HashSet<ProductImages>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int Qty { get; set; }

        public string Photo { get; set; }

        public string Type { get; set; }

        public string SupplierName { get; set; }

        public DateTime EntryDate { get; set; }

        public string ReviewUrl { get; set; }

        public virtual ICollection<ProductImages> ProductImages { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }


    }
}
