using Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Repository
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Food> Foods { get; set; } = null!;
        public DbSet<Person> Persons { get; set; } = null!;
        public DbSet<Reustarant> Reustarants { get; set; } = null!;
        public DbSet<ShoppingList> ShoppingLists { get; set; } = null!;
        public DbSet<BuyerInfo> BuyerInfos { get; set; } = null!;
        public DbSet<Basket> Baskets { get; set; } = null!;

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
        { }
    }
}
