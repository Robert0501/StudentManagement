using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.DTOs.UserProfileDTO
{
    public class GetUserProfileDTO
    {
        public int UserProfileId { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        [DefaultValue("false")]
        public bool IsActive { get; set; } = false;
        [DefaultValue("false")]
        public bool IsDeleted { get; set; } = false;
        [DefaultValue(1)]
        public PersonType Type { get; set; } = PersonType.Student;
        public virtual UserToken? userToken { get; set; }
    }
}