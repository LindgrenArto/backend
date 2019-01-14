using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiExample.Models;
using WebApiExample.Services;

namespace WebApiExample.Controllers
{
    [Route("api/person")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }
        
        // GET api/person
        [HttpGet]
        public ActionResult<List<Person>> GetPersons()
        {
            var persons = _personService.Read();
            return new JsonResult(persons);
        }

        // GET api/person/5
        [HttpGet("{id}")]
        public ActionResult<Person> Get(int id)
        {
            var person = _personService.Read(id);
            return new JsonResult(person);
        }

        [HttpPost]
        public ActionResult<Person> Create([FromBody] Person person)
        {
            Person createdPerson = _personService.CreatePerson(person);
            return new JsonResult(person);
        }

        [HttpPut("{id}")]
        public ActionResult<Person> Update(int id ,[FromBody]  Person person)
        {
            Person updatedPerson = _personService.Update(id, person);
            return new JsonResult(updatedPerson);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _personService.Delete(id);
            return new OkResult();
        }
    }
}