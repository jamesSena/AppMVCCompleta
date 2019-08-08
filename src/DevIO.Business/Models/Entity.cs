using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppMVC.Models
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
