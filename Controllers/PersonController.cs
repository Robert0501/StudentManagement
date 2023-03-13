using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace StudentManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private List<Person> persons = new List<Person>();

        public PersonController()
        {
            persons.Add(new Person((persons.Count() + 1), "Robert", "robert_amza@yahoo.com", "+40770895664", new Address(persons.Count() + 1, "Romania", "Craiova", "Visinului", 12), PersonType.Student));
            persons.Add(new Person((persons.Count() + 1), "Robert", "robert_amza@yahoo.com", "+40770895664", new Address(persons.Count() + 1, "Romania", "Craiova", "Visinului", 12), PersonType.Student));
        }

        [HttpGet("GetAllPersons")]
        public ActionResult<List<Person>> GetAll()
        {
            return Ok(persons);
        }

        [HttpGet("{id}")]
        public ActionResult<Person> GetPersonById(int id)
        {
            var person = persons.FirstOrDefault(p => p.Id == id);
            if (person is null)
            {
                return NotFound("The person you are looking for was not found");
            }
            return Ok(person);
        }

        [HttpPost("AddNewPerson")]
        public ActionResult<List<Person>> AddPerson(Person newPerson)
        {
            persons.Add(newPerson);
            return Ok(persons);
        }

        [HttpPut("UpdatePerson")]
        public ActionResult<Person> UpdatePerson(Person updatedPerson)
        {
            var oldPerson = persons.FirstOrDefault(p => p.Id == updatedPerson.Id);

            oldPerson.Name = updatedPerson.Name;
            oldPerson.Email = updatedPerson.Email;
            oldPerson.Address = updatedPerson.Address;
            oldPerson.PhoneNumber = updatedPerson.PhoneNumber;
            oldPerson.type = updatedPerson.type;

            return Ok(oldPerson);
        }

        [HttpDelete("{id}")]
        public ActionResult<List<Person>> DeletePerson(int id)
        {
            var person = persons.FirstOrDefault(p => p.Id == id);
            persons.Remove(person);
            return Ok(persons);
        }
    }
}