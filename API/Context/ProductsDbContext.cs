using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using ecommerce.Data;
using Microsoft.EntityFrameworkCore;

namespace ecommerce.Context
{
    public class ProductsDbContext:DbContext
    {
         public ProductsDbContext(DbContextOptions<ProductsDbContext> options)
            : base(options)
        {
        }

         protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        public DbSet<Entities> Products { get; set; }
    }
}