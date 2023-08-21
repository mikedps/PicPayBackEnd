using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicPayBackEnd.Data.DTOs
{
    public class Result
    {
        public Result()
        {
        }
        public Result(bool success, IList<string> messages)
        {
            Success = success;
            Messages = messages;
        }
        public bool Success { get; set; }   
        public IList<string> Messages { get; set; } = new List<string>();


        public void AddError(string message) => Messages.Add(message);
        
    }
}
