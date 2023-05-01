using Data;
using Repository.PersonRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.PersonRepo
{

    public class PersonRepository : IPersonRepository
    {
        private readonly ApplicationContext _context;

        public PersonRepository(ApplicationContext context)
        {
            _context = context;
        }

        public List<Person> GetAll()
        {
            return _context.Persons.ToList();
        }

        public Person Get(int id)
        {
            return _context.Persons.FirstOrDefault(b => b.Id == id);
        }

        public void Create(Person Person)
        {
            _context.Persons.Add(Person);
        }

        public void Update(Person Person)
        {
            _context.Persons.Update(Person);
        }

        public void Delete(int id)
        {
            Person Person = Get(id);
            _context.Persons.Remove(Person);
        }
    }
}
