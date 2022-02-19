using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestAspNet3.data.models;

namespace TestAspNet3.data
{
    public class DB : DbContext 
    {
        public DB(DbContextOptions<DB> options) : base(options)
        {

        }

        public DbSet<Product> product { get; set; }
        public DbSet<Category> category { get; set; }
        public DbSet<CartItem> cartItem { get; set; }
        public DbSet<Order> order { get; set; }
        public DbSet<OrderDetail> orderDetail { get; set; }
    }
}
