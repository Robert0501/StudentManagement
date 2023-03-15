using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace StudentManagement.Services
{
    public class PersonService : IPersonService
    {
        private readonly DataContext _context;

        public PersonService(DataContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<Person>>> GetAllPersons()
        {
            var serviceResponse = new ServiceResponse<List<Person>>();
            serviceResponse.Data = await _context.Person.ToListAsync();
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
            serviceResponse.Data = await _context.Person.FirstOrDefaultAsync(p => p.PersonId == id);
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
            _context.Person.Add(newPerson);
            await _context.SaveChangesAsync();
            serviceResponse.Data = await _context.Person.ToListAsync();
            return serviceResponse;
        }

        public async Task<ServiceResponse<Person>> UpdatePerson(Person updatedPerson)
        {
            var serviceResponse = new ServiceResponse<Person>();
            var newPerson = await _context.Person.FirstOrDefaultAsync(p => p.PersonId == updatedPerson.PersonId);

            if (newPerson is null)
            {
                throw new Exception($"Person with ID '{updatedPerson.PersonId}' not found");
            }

            newPerson.Name = updatedPerson.Name;
            newPerson.Email = updatedPerson.Email;
            newPerson.PhoneNumber = updatedPerson.PhoneNumber;
            newPerson.Address = updatedPerson.Address;
            newPerson.type = updatedPerson.type;

            await _context.SaveChangesAsync();

            serviceResponse.Data = newPerson;

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Person>>> DeletePerson(int id)
        {
            var serviceResponse = new ServiceResponse<List<Person>>();
            var deletedPerson = await _context.Person.FirstOrDefaultAsync(p => p.PersonId == id);
            serviceResponse.Data = await _context.Person.ToListAsync();

            if (deletedPerson is null)
                throw new Exception($"Person with ID '{id}' not found");

            _context.Person.Remove(deletedPerson);
            await _context.SaveChangesAsync();
            return serviceResponse;
        }
    }
}