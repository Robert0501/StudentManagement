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
        private readonly IStudentService _studentService;

        public PersonController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet("GetAllPersons")]
        public ActionResult<List<Person>> GetAll()
        {
            return Ok(_studentService.GetAllPersons());
        }


        [HttpGet("{id}")]
        public ActionResult<Person> GetPersonById(int id)
        {
            var person = _studentService.GetPersonById(id);
            if (person is null)
            {
                return NotFound("The person you are looking for was not found");
            }
            return Ok(person);
        }

        [HttpPost("AddNewPerson")]
        public ActionResult<List<Person>> AddPerson(Person newPerson)
        {

            return Ok(_studentService.AddNewPerson(newPerson));
        }

        [HttpPut("UpdatePerson")]
        public ActionResult<Person> UpdatePerson(Person updatedPerson)
        {
            return Ok(_studentService.UpdatePerson(updatedPerson));
        }

        [HttpDelete("{id}")]
        public ActionResult<List<Person>> DeletePerson(int id)
        {

            return Ok(_studentService.DeletePerson(id));
        }

    }
}