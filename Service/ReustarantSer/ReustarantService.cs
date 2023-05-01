using Data;
using Repository.ReustarantRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ReustarantSer
{
    public class ReustarantService : IReustarantService
    {
        private IReustarantRepository _repository;

        public ReustarantService(IReustarantRepository repository)
        {
            _repository = repository;
        }

        public List<Reustarant> GetReustarants()
        {
            return _repository.GetAll();
        }

        public Reustarant GetReustarantById(int id)
        {
            return _repository.Get(id);
        }

        public void CreateReustarant(Reustarant Reustarant)
        {
            _repository.Create(Reustarant);
        }

        public void UpdateReustarant(Reustarant Reustarant)
        {
            _repository.Update(Reustarant);
        }

        public void DeleteReustarant(int id)
        {
            _repository.Delete(id);
        }
    }
}
