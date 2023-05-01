using Data;
using Repository.ReustarantRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.ReustarantRepo
{

    public class ReustarantRepository : IReustarantRepository
    {
        private readonly ApplicationContext _context;

        public ReustarantRepository(ApplicationContext context)
        {
            _context = context;
        }

        public List<Reustarant> GetAll()
        {
            return _context.Reustarants.ToList();
        }

        public Reustarant Get(int id)
        {
            return _context.Reustarants.FirstOrDefault(b => b.Id == id);
        }

        public void Create(Reustarant Reustarant)
        {
            _context.Reustarants.Add(Reustarant);
        }

        public void Update(Reustarant Reustarant)
        {
            _context.Reustarants.Update(Reustarant);
        }

        public void Delete(int id)
        {
            Reustarant Reustarant = Get(id);
            _context.Reustarants.Remove(Reustarant);
        }
    }
}
