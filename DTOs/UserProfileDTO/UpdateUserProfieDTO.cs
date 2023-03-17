using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.DTOs.UserProfileDTO
{
    public class UpdateUserProfieDTO
    {
        public int UserProfileId { get; set; }
        public string Password { get; set; }
    }
}