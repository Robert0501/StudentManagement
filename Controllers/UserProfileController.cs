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
        public async Task<ActionResult<ServiceResponse<List<UserProfile>>>> GetAllUsers()
        {
            var response = await _userProfileService.GetAllUsers();
            if (response.Success is false)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<UserProfile>>> GetUserById(int id)
        {
            var response = await _userProfileService.GetUserById(id);
            if (response.Success is false)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpPost("AddNewProfile")]
        public async Task<ActionResult<ServiceResponse<List<UserProfile>>>> AddNewProfile(UserProfile newProfile)
        {
            var response = await _userProfileService.AddNewProfile(newProfile);
            if (response.Success is false)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpPut("UpdateProfile")]
        public async Task<ActionResult<UserProfile>> UpdateProfile(UserProfile updatedProfile)
        {
            var response = await _userProfileService.UpdateProfile(updatedProfile);
            if (response.Success is false)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<UserProfile>>> DeleteProfile(int id)
        {
            var response = await _userProfileService.DeleteUser(id);
            if (response.Success is false)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

    }
}