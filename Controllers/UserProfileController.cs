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
        private readonly IUserProfileService _userProfileService;

        public UserProfileController(IUserProfileService userProfileService)
        {
            _userProfileService = userProfileService;
        }



        [HttpGet("GetAllUsers")]
        public ActionResult<List<UserProfile>> GetAllUsers()
        {
            return Ok(_userProfileService.GetAllUsers());
        }

        [HttpGet("{id}")]
        public ActionResult<UserProfile> GetUserById(int id)
        {

            return Ok(_userProfileService.GetUserById(id));
        }

        [HttpPost("AddNewProfile")]
        public ActionResult<List<UserProfile>> AddNewProfile(UserProfile newProfile)
        {
            return Ok(_userProfileService.AddNewProfile(newProfile));
        }

        [HttpPut("UpdateProfile")]
        public ActionResult<UserProfile> UpdateProfile(UserProfile updatedProfile)
        {

            return Ok(_userProfileService.UpdateProfile(updatedProfile));
        }

        [HttpDelete("{id}")]
        public ActionResult<List<UserProfile>> DeleteProfile(int id)
        {


            return Ok(_userProfileService.DeleteUser(id));
        }

    }
}