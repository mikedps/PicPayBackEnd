using MediatR;
using Microsoft.AspNetCore.Mvc;
using PicPayBackEnd.Data.Commands;

namespace PicPayBackEnd.API.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ISender _mediatr;

        public UserController(ISender mediatr)
        {
            _mediatr = mediatr;
        }

        [HttpPost("create")]
        public async Task<ActionResult> Post(CreateUserCommand request)
        {
            var result = await _mediatr.Send(request);
            
            if(result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        /*

        [HttpGet("users")]
        public async Task<ActionResult> GetUsers()
        {
            return Ok(await _userService.GetAllUsers());
            
        }
        */

    }
}
