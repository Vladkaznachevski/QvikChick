using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class ShoppingList : BaseEntity
    {
        public List<Food> Foods { get; set; }
        public int Price { get; set; }
        public int Sale { get; set;}

    }
}
