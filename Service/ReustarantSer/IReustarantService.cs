using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ReustarantSer
{
    public interface IReustarantService
    {
        List<Reustarant> GetReustarants();
        Reustarant GetReustarantById(int id);
        void CreateReustarant(Reustarant Reustarant);
        void UpdateReustarant(Reustarant Reustarant);
        void DeleteReustarant(int id);
    }
}
