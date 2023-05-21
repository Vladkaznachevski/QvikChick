﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Order
    {
        public int id { get; set; } 
        public string name { get; set; }    
        public string surname { get; set; }
        public string address { get; set; }

        public string phone { get; set; }

        public string email { get; set; }

        public DateTime orderTime { get; set; }

        public List<OrderDetail> orderDetails { get; set; }


    }
}