using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.Services.Student
{
    public interface IPersonService
    {
        Task<ServiceResponse<List<Person>>> GetAllPersons();
        Task<ServiceResponse<Person>> GetPersonById(int id);
        Task<ServiceResponse<List<Person>>> AddNewPerson(Person newPerson);
        Task<ServiceResponse<Person>> UpdatePerson(Person updatedPerson);
        Task<ServiceResponse<List<Person>>> DeletePerson(int id);
    }
}