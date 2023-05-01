using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.PersonSer
{
    public interface IPersonService
    {
        List<Person> GetPersons();
        Person GetPersonById(int id);
        void CreatePerson(Person Person);
        void UpdatePerson(Person Person);
        void DeletePerson(int id);
    }
}
