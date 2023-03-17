using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserProfileController : ControllerBase
    {

        private static List<UserProfile> users = new List<UserProfile>
        {
            new UserProfile("rob@gmail.com", "rob", PersonType.Student)
        };

        [HttpGet("GetAllUsers")]
        public ActionResult<List<UserProfile>> GetAllUsers()
        {
            return Ok(users);
        }

        [HttpGet("{id}")]
        public ActionResult<UserProfile> GetUserById(int id)
        {
            var user = users.FirstOrDefault(u => u.UserProfileId == id);
            return Ok(user);
        }

        [HttpPost("AddNewProfile")]
        public ActionResult<List<UserProfile>> AddNewProfile(UserProfile newProfile)
        {
            users.Add(newProfile);
            return Ok(users);
        }

        [HttpPut("UpdateProfile")]
        public ActionResult<UserProfile> UpdateProfile(UserProfile updatedProfile)
        {
            var user = users.FirstOrDefault(u => u.UserProfileId == updatedProfile.UserProfileId);

            user.Email = updatedProfile.Email;
            user.Password = updatedProfile.Password;

            return Ok(user);
        }

        [HttpDelete("{id}")]
        public ActionResult<List<UserProfile>> DeleteProfile(int id)
        {
            var user = users.FirstOrDefault(u => u.UserProfileId == id);
            users.Remove(user);

            return Ok(users);
        }

    }
}