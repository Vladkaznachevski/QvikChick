using Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Repository
{
    public class ApplicationContext : IdentityDbContext<User>
    {
        public DbSet<Food> Foods { get; set; } = null!;
  
        //      public DbSet<Reustarant> Reustarants { get; set; } = null!;
        public DbSet<ShopCartItem> ShopCartItems { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<OrderDetail> OrderDetails { get; set; } = null!;

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
        {

            Database.EnsureCreated(); // создаем базу данных при первом обращении
            
        }

}
}
