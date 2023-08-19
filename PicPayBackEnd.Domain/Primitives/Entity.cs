using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicPayBackEnd.Domain.Primitives
{
    public abstract class Entity
    {
        public Entity()
        {
            Id = Guid.NewGuid();            
        }
        public Guid Id { get; protected set; }
    }
}
