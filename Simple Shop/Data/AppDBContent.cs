using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Simple_Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Simple_Shop.Data
{
    public class AppDBContent : DbContext
    {
        public AppDBContent(DbContextOptions<AppDBContent> options) : base(options)
        {

        }

        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Order> Order{ get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }

    }
}
