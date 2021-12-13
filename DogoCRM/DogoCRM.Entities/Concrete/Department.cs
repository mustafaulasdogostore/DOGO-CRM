﻿using DogoCRM.Entities.Abstract;
using DogoCRM.Shared.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogoCRM.Entities.Concrete
{
  public  class Department:EntityBase,IEntity
    {

        public string Name { get; set; }

      
        public List<User> Users { get; set; }

    }
}
