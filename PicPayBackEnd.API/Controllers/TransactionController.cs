using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PicPayBackEnd.Data.Commands;
using PicPayBackEnd.Data.DTOs;

namespace PicPayBackEnd.API.Controllers
{
    [Route("api/transaction")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ISender _mediatr;

        public TransactionController(ISender mediatr)
        {
            _mediatr = mediatr;
        }

        [HttpPost("create")]   
        public async Task<ActionResult> Post(CreateTransactionCommand request)
        {
            var resultado = await _mediatr.Send(request);

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
