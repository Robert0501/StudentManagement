using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.Models
{
    public class Address
    {
        public int PersonId { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }

        public Address(int personId, string country, string city, string street, int number)
        {
            this.PersonId = personId;
            this.Country = country;
            this.City = city;
            this.Street = street;
            this.Number = number;
        }
    }
}