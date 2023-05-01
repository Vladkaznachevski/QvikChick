using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Repository.PersonRepo;

namespace Service.PersonSer
{
    public class PersonService : IPersonService
    {
        private IPersonRepository _repository;

        public PersonService(IPersonRepository repository)
        {
            _repository = repository;
        }

        public List<Person> GetPersons()
        {
            return _repository.GetAll();
        }

        public Person GetPersonById(int id)
        {
            return _repository.Get(id);
        }

        public void CreatePerson(Person Person)
        {
            _repository.Create(Person);
        }

        public void UpdatePerson(Person Person)
        {
            _repository.Update(Person);
        }

        public void DeletePerson(int id)
        {
            _repository.Delete(id);
        }
    }
}
