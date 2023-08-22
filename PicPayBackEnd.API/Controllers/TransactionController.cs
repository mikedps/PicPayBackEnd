using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PicPayBackEnd.Data.DTOs;
using PicPayBackEnd.Data.Services;

namespace PicPayBackEnd.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;
        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpPost]   
        public ActionResult Post(TransactionDTO request)
        {
            var resultado = _transactionService.CreateTransaction(request);

            if(resultado.Success)
            {
                return Ok(resultado);
            }
            else
            {
                return BadRequest(resultado);
            }
        }

        [HttpGet] 
        public ActionResult Get() 
        {
            return Ok("Ok");
        }
    }
}
