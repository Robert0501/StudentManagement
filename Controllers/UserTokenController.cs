using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserTokenController : ControllerBase
    {
        private readonly IUserTokenService _userTokenService;
        public UserTokenController(IUserTokenService userTokenService)
        {
            _userTokenService = userTokenService;
        }

        [HttpPost("GenerateToken")]
        public ActionResult<int> GenerateNewToken()
        {
            return Ok(_userTokenService.GenerateToken());
        }

        [HttpPut("UpdateToken")]
        public async Task<ActionResult<UserToken>> UpdateToken(UserToken updatedToken)
        {
            return Ok(await _userTokenService.UpdateToken(updatedToken));
        }

        [HttpGet("id")]
        public async Task<ActionResult<UserToken>> GetTokenById(int id)
        {
            return Ok(await _userTokenService.GetTokenById(id));
        }
    }
}