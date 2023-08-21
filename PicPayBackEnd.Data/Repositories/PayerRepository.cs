using Microsoft.Identity.Client;
using PicPayBackEnd.Data.Context;
using PicPayBackEnd.Data.DTOs;
using PicPayBackEnd.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicPayBackEnd.Data.Repositories
{
    public class PayerRepository : IPayerRepository
    {
        private readonly PicPayContext _context;
        public PayerRepository(PicPayContext context)
        {
            _context = context;
        }


        public void Create(Payer payer)
        {
            _context.Set<Payer>().Add(payer);

            _context.SaveChanges();
        }
       
    }
}
