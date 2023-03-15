using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace StudentManagement.Models
{
    public class Person
    {
        public int PersonId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        [ForeignKey("AddressId")]
        public virtual Address? Address { get; set; }
        public PersonType type { get; set; }

        public Person(string name, string email, string phoneNumber, PersonType type)
        {
            this.Name = name;
            this.Email = email;
            this.PhoneNumber = phoneNumber;
            this.type = type;
        }
    }
}