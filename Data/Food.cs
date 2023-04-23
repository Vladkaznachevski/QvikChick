using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Food : BaseEntity
    {

        public string Name { get; set; }
        public string Description { get; set; }
        public string Size { get; set; }
    }
}
