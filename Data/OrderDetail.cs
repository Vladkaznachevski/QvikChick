using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    namespace Data
{
    public class OrderDetail
    {
        public int id { get; set; }
        public int orderId { get; set; }
        public int foodId { get; set; }
  
        public Food Food { get; set; }  
        public Order Order { get; set; }

    }
}