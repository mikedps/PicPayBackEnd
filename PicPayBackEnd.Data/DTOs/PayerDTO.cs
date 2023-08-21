using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PicPayBackEnd.Data.DTOs
{
    public class PayerDTO
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Surename { get;set; }

        public string Cpf { get; set; }

        public string Email { get; set; }   

    }
}
