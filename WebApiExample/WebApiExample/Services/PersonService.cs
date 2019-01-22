using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiExample.Models;
using WebApiExample.Repositories;

namespace WebApiExample.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public Person CreatePerson(Person person)
        {
           return _personRepository.Create(person);
        }

        public void Delete(int id)
        {
            _personRepository.Delete(id);
        }

        public List<Person> Read()
        {
            return _personRepository.Read();
        }

        public Person Read(int id)
        {
            return _personRepository.Read(id);
        }

        public Person Update(int id, Person person)
        {
            var savedPerson = _personRepository.Read(id);
            if(savedPerson == null)
            {
                throw new Exception("Person not found");
            }
            else
            {
               return _personRepository.Update(id, person);
            }
        }
    }
}
