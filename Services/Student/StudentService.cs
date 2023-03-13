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
            new Person( 2, "Ionut", "ionut@yahoo.com", "+40770895475", new Address(2, "Romania", "Craiova", "Buciumului", 12), PersonType.Student)
        };

        public List<Person> GetAllPersons()
        {
            return persons;
        }

        public Person GetPersonById(int id)
        {
            var person = persons.FirstOrDefault(p => p.Id == id);
            return person;
        }

        public List<Person> AddNewPerson(Person newPerson)
        {
            persons.Add(newPerson);
            return persons;
        }

        public Person UpdatePerson(Person updatedPerson)
        {
            var newPerson = persons.FirstOrDefault(p => p.Id == updatedPerson.Id);

            newPerson.Name = updatedPerson.Name;
            newPerson.Email = updatedPerson.Email;
            newPerson.Address = updatedPerson.Address;
            newPerson.PhoneNumber = updatedPerson.PhoneNumber;
            newPerson.type = updatedPerson.type;

            return newPerson;
        }

        public List<Person> DeletePerson(int id)
        {
            var deletedPerson = persons.FirstOrDefault(p => p.Id == id);
            persons.Remove(deletedPerson);
            return persons;
        }
    }
}