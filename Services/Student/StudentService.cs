using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace StudentManagement.Services
{
    public class StudentService : IStudentService
    {
        private static List<Person> persons = new List<Person> {
            new Person(1, "Robert", "robert_amza@yahoo.com", "+40770895664", new Address(1, "Romania", "Craiova", "Visinului", 12), PersonType.Student),
            new Person(2, "Ionut", "ionut@yahoo.com", "+40770895475", new Address(2, "Romania", "Craiova", "Buciumului", 12), PersonType.Student)
        };

        public async Task<ServiceResponse<List<Person>>> GetAllPersons()
        {
            var serviceResponse = new ServiceResponse<List<Person>>();
            serviceResponse.Data = persons;
            if (serviceResponse.Data is null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "There are no persons added";
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<Person>> GetPersonById(int id)
        {
            var serviceResponse = new ServiceResponse<Person>();
            serviceResponse.Data = persons.FirstOrDefault(p => p.Id == id);
            if (serviceResponse.Data is null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "The person you are tring to find was not found";
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Person>>> AddNewPerson(Person newPerson)
        {
            var serviceResponse = new ServiceResponse<List<Person>>();
            serviceResponse.Data = persons;
            serviceResponse.Data.Add(newPerson);
            return serviceResponse;
        }

        public async Task<ServiceResponse<Person>> UpdatePerson(Person updatedPerson)
        {
            var serviceResponse = new ServiceResponse<Person>();
            var newPerson = persons.FirstOrDefault(p => p.Id == updatedPerson.Id);

            newPerson.Name = updatedPerson.Name;
            newPerson.Email = updatedPerson.Email;
            newPerson.Address = updatedPerson.Address;
            newPerson.PhoneNumber = updatedPerson.PhoneNumber;
            newPerson.type = updatedPerson.type;

            serviceResponse.Data = newPerson;

            if (serviceResponse.Data is null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "We could not update your data";
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Person>>> DeletePerson(int id)
        {
            var serviceResponse = new ServiceResponse<List<Person>>();
            serviceResponse.Data = persons;
            var deletedPerson = persons.FirstOrDefault(p => p.Id == id);
            serviceResponse.Data.Remove(deletedPerson);
            if (deletedPerson is null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "We could not find the person you are looking for";
            }
            return serviceResponse;
        }
    }
}