using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PicPayBackEnd.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        [HttpGet]   
        public ActionResult Get()
        {
            return Ok("Ok");
        }
    }
}
