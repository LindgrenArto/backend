using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiExample.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApiExample.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly PersondbContext _context;

        public PersonRepository(PersondbContext persondbContext)
        {
            _context = persondbContext;
        }

        public Person Create(Person person)
        {
            _context.Add(person);
            _context.SaveChanges();
            return person;
        }

        public void Delete(int id)
        {
            var person = Read(id);
            _context.Remove(person);
            _context.SaveChanges();
            return;

        }

        public List<Person> Read()
        {
            return _context.Person.AsNoTracking()
                .Include(p => p.Phone)
                .ToList();
        }

        public Person Read(int id)
        {
            return _context.Person.AsNoTracking().Include(p => p.Phone).FirstOrDefault(p => p.Id == id);
        }

        public Person Update(int id, Person person)
        {
            _context.Update(person);
            _context.SaveChanges();
            return person;
        }
    }
}
