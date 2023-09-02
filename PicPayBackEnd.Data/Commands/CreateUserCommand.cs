using MediatR;
using PicPayBackEnd.Data.DTOs;
using PicPayBackEnd.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicPayBackEnd.Data.Commands
{
    public class CreateUserCommand : IRequest<Result>
    {
        public UserType UserType { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string DocumentID { get; set; }

        public string Email { get; set; }

    }
}
