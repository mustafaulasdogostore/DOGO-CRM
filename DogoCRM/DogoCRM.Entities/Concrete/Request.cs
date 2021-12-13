using DogoCRM.Entities.Abstract;
using DogoCRM.Shared.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogoCRM.Entities.Concrete
{
   public class Request : EntityBase, IEntity
    {

        public int UserId { get; set; }
      
        public string Title { get; set; }

        public string Status { get; set; } 

        public string Description { get; set; }


        public string Picture { get; set; }

        public int ImportanceLevel { get; set; }

        public virtual User User { get; set; }
    }
}
