using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.Services.Student
{
    public interface IStudentService
    {
        List<Person> GetAllPersons();
        Person GetPersonById(int id);
        List<Person> AddNewPerson(Person newPerson);
        Person UpdatePerson(Person updatedPerson);
        List<Person> DeletePerson(int id);
    }
}