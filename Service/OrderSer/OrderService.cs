using Data;
using Repository.OrderRepo;
using Service.OrderSer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.OrderService
{
    public class OrderService : IOrderService
    {
        private IOrdersRepository _repository;


        public OrderService(IOrdersRepository repository)
        {
            _repository = repository;
        }

        public void CreateOrder(Order order)
        {
            _repository.CreateOrder(order);
        }


    }
}
