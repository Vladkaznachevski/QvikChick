using System;
using Repository;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Repository.ShopCartRepo;

namespace Repository.OrderRepo
{
    public class OrdersRepository : IOrdersRepository
    {

        private readonly ApplicationContext _context;

        private readonly ShopCartRepository shopCart;
        public OrdersRepository(ApplicationContext context, ShopCartRepository shopCart){
            _context = context;
            this.shopCart = shopCart;
        }


        public void createOrder(Order order)
        {
            order.orderTime = DateTime.Now;
            _context.Orders.Add(order);
            var items = shopCart.listShopItems;
            foreach (var item in items) 
            {
                var orderDetail = new OrderDetail()
                {
                    foodID = item.food.Id,
                    orderID = order.id,
                   // price = item.food.Size
                };
                _context.OrderDetails.Add(orderDetail);
            }
            _context.SaveChanges();
        }
    }
}
