using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevIO.Business.Models
{
    public abstract class Entity
    {
        protected Entity()
        {
            ID = new Guid();
        }
        public Guid ID { get; set; }


    }
}
