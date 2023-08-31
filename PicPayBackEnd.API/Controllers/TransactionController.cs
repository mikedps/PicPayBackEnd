using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PicPayBackEnd.Data.DTOs;
using PicPayBackEnd.Data.Services;

namespace PicPayBackEnd.API.Controllers
{
    [Route("api/transaction")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;
        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpPost("create")]   
        public async Task<ActionResult> Post(TransactionDTO request)
        {
            var resultado = await _transactionService.CreateTransaction(request);

            if(resultado.Success)
            {
                return Ok(resultado);
            }
            else
            {
                return BadRequest(resultado);
            }
        }

    }
}
