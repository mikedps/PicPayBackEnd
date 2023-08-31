using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using PicPayBackEnd.Domain.Enums;

namespace PicPayBackEnd.Data.DTOs
{
    public class UserDTO
    {
        public Guid ID { get; set; }

        public UserType UserType { get; set; }

        public string? Name { get; set; }

        public string? Surname { get;set; }

        public string FullName => $"{ Name} {Surname}";

        public string DocumentID { get; set; }

        public string Email { get; set; }


    }
}
