﻿using DogoCRM.Shared.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogoCRM.Entities.Concrete.DTOS
{
   public class DepartmentListDto : DtoGetBase
    {
        public IList<Department> Departments  { get; set; }
    }
}
