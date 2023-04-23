using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class BuyerInfo : BaseEntity
    {

        public Person Person { get; set; }
        public Reustarant Reustarant { get; set; }
        public DateTime Time { get; set; }

    }
}
