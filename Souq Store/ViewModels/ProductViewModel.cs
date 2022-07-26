using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Souq_Store.ViewModels
{
    public class ProductViewModel
    {
        [Required]
        [Display(Name ="Product Category")]
        public string CatName { get; set; }

        [Required]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }

        [Display(Name = "Product Price")]
        public decimal ProductPrice { get; set; }

        [Display(Name = "Product Quantity")]
        public int Productquantity { get; set; }
    }
}
