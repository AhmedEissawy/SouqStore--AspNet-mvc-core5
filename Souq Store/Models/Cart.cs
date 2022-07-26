using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Souq_Store.Models
{
    public class Cart
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public int ProductId { get; set; }

        public int Qty { get; set; }

        public virtual Product Product { get; set; }

        public virtual IdentityUser User { get; set; }
    }
}
