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
        public async Task<ActionResult<ServiceResponse<List<Person>>>> GetAll()
        {
            var response = await _studentService.GetAllPersons();
            if (response.Data is null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<Person>>> GetPersonById(int id)
        {

            var response = await _studentService.GetPersonById(id);
            if (response.Data is null)
            {
                return NotFound("The person you are looking for was not found");
            }
            return Ok(response);
        }

        [HttpPost("AddNewPerson")]
        public async Task<ActionResult<ServiceResponse<List<Person>>>> AddPerson(Person newPerson)
        {
            var response = await _studentService.AddNewPerson(newPerson);
            return Ok(response);
        }

        [HttpPut("UpdatePerson")]
        public async Task<ActionResult<ServiceResponse<Person>>> UpdatePerson(Person updatedPerson)
        {
            var response = await _studentService.UpdatePerson(updatedPerson);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Person>>> DeletePerson(int id)
        {
            var response = await _studentService.DeletePerson(id);
            if (!response.Success)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

    }
}