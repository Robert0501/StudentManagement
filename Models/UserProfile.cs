using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.Models
{
    public class UserProfile
    {
        public int UserProfileId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; } = false;
        public bool IsDeleted { get; set; } = false;
        public PersonType Type { get; set; } = PersonType.Student;

        public UserProfile(string email, string password, PersonType type)
        {
            this.Email = email;
            this.Password = password;
            this.IsActive = false;
            this.IsDeleted = false;
            this.Type = type;
        }
    }
}