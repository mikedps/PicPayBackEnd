using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PicPayBackEnd.Data.DTOs;
using PicPayBackEnd.Data.Services;

namespace PicPayBackEnd.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public IActionResult Post(UserDTO data)
        {
            var result = _userService.CreateUser(data);
            
            if(result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
    }
}
