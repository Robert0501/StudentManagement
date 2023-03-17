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
        [DefaultValue("false")]
        public bool IsActive { get; set; } = false;
        [DefaultValue("false")]
        public bool IsDeleted { get; set; } = false;
        [DefaultValue(1)]
        public PersonType Type { get; set; } = PersonType.Student;

        [ForeignKey("UserTokenId")]
        public virtual UserToken? userToken { get; set; }

        public UserProfile()
        {

        }
        public UserProfile(String email, String password)
        {
            this.Email = email;
            this.Password = password;
        }
        public UserProfile(string email, string password, bool isActive, bool IsDeleted, PersonType type)
        {
            this.Email = email;
            this.Password = password;
            this.IsActive = isActive;
            this.IsDeleted = IsDeleted;
            this.Type = type;
        }
    }
}