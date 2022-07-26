using Souq_Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Souq_Store.ViewModels
{
    public class IndexViewModel
    {
        public IndexViewModel()
        {

            Categories = new List<Category>();

            LatestProducts = new List<Product>();

            reviews = new List<Review>();
        }

        public List<Category> Categories { get; set; }

        public List<Product> LatestProducts { get; set; }

        public List<Review> reviews { get; set; }
    }
}
