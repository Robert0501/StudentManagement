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
        public async Task<ActionResult<ServiceResponse<List<GetUserProfileDTO>>>> GetAllUsers()
        {
            var response = await _userProfileService.GetAllUsers();
            if (response.Success is false)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetUserProfileDTO>>> GetUserById(int id)
        {
            var response = await _userProfileService.GetUserById(id);
            if (response.Success is false)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpPost("CreateAccount")]
        public async Task<ActionResult<ServiceResponse<List<GetUserProfileDTO>>>> AddNewProfile(AddUserProfileDTO newProfile)
        {
            var response = await _userProfileService.AddNewProfile(newProfile);
            if (response.Success is false)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPut("ChangePassowrd")]
        public async Task<ActionResult<GetUserProfileDTO>> UpdateProfile(UpdateUserProfieDTO updatedProfile)
        {
            var response = await _userProfileService.UpdateProfile(updatedProfile);
            if (response.Success is false)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpDelete("DeleteAccount/{id}")]
        public async Task<ActionResult<List<GetUserProfileDTO>>> DeleteProfile(int id)
        {
            var response = await _userProfileService.DeleteUser(id);
            if (response.Success is false)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpPut("ActivateAccount")]
        public async Task<ActionResult<ServiceResponse<UserProfile>>> ActivateAccount(int userProfileId, int insertedToken)
        {
            var response = await _userProfileService.ActivateAccount(userProfileId, insertedToken);
            return Ok(response);
        }

    }
}