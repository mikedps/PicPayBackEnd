using PicPayBackEnd.Data.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicPayBackEnd.Data.Services
{
    public interface IUserService
    {
        Result CreateUser(UserDTO request);
    }
}
