using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Microsoft.EntityFrameworkCore;

namespace Repository.ShopCartRepo
{
    public class ShopCartRepository
    {
        private readonly ApplicationContext _context;

        public ShopCartRepository(ApplicationContext context) { _context = context; }
        public string ShopCartId { get; set; }

        public List<ShopCartItem> listShopItems { get; set; }

        public static ShopCartRepository GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<ApplicationContext>();
            string shopCartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", shopCartId);
            return new ShopCartRepository(context) { ShopCartId = shopCartId };

        }

        public void AddToCart(Food food)
        {
            _context.ShopCartItems.Add(new ShopCartItem
            {
                ShopCartId = ShopCartId,
                food = food,
                Description = food.Description,
                Size = food.Size,

            });
            _context.SaveChanges();
        }


        public List<ShopCartItem> GetShopItems()
        {  
            return _context.ShopCartItems.Where(c => c.ShopCartId == ShopCartId).Include(c => c.food).ToList();
        }


    }


}




 


