using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PicPayBackEnd.Data.DTOs;
using PicPayBackEnd.Data.Services;

namespace PicPayBackEnd.API.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("create")]
        public async Task<ActionResult> Post(UserDTO data)
        {
            var result = await _userService.CreateUser(data);
            
            if(result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpGet("users")]
        public async Task<ActionResult> GetUsers()
        {
            return Ok(await _userService.GetAllUsers());
            
        }
    }
}
