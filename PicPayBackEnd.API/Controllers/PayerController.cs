using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PicPayBackEnd.Data.DTOs;
using PicPayBackEnd.Data.Services;

namespace PicPayBackEnd.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PayerController : ControllerBase
    {
        private readonly IPayerService _payerService;

        public PayerController(IPayerService payerService)
        {
            _payerService = payerService;
        }

        [HttpPost]
        public IActionResult Post(PayerDTO data)
        {
            var result = _payerService.CreatePayer(data);
            
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
