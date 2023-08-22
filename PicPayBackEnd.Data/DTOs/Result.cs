using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PicPayBackEnd.Data.DTOs
{
    public class Result
    {
        public Result()
        {
        }
        public Result(IList<string> messages)
        {
            Messages = messages;
        }
        
        public bool Success => Valid;

        [JsonIgnore]
        public bool Valid => !Messages.Any();
        public IList<string> Messages { get; set; } = new List<string>();


        public void AddError(string message) => Messages.Add(message);
        
    }
}
