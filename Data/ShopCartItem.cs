using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class ShopCartItem
    {
        public int Id { get; set; }
        public Food food { get; set; }
        public string Description { get; set; }
        public string Size { get; set; }

        public string ShopCartId { get; set; }  

    }
}
