using System;
using Repository;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Repository.ShopCartRepo;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Security.Cryptography;
using static System.Formats.Asn1.AsnWriter;

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


        public void CreateOrder(Order order)
        {
            order.orderTime = DateTime.Now; // Задаём время заказа

            _context.Orders.Add(order); // Добавляем заказ в SQL таблицу
            _context.SaveChanges();

            var items = shopCart.listShopItems; // Получаем список товаров из корзины
            foreach (var el in items)  // Перебираем корзину
            {
                var orderDetail = new OrderDetail() // создаём класс информации о заказе
                {
                    foodId = el.food.Id, // Заполняем айди Еды
                    orderId = order.id, // заполняем айди Заказа
                };
                _context.OrderDetails.Add(orderDetail);
            }
            _context.SaveChanges();

        }
    }
}
