using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Souq_Store.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Souq_Store.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<ProductImages> ProductImages { get; set; }

        public virtual DbSet<Review> Reviews { get; set; }

        public virtual DbSet<Cart>  Carts { get; set; }
    }
}
