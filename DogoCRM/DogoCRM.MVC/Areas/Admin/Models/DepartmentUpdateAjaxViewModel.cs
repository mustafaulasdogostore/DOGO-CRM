using DogoCRM.Entities.Concrete.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogoCRM.MVC.Areas.Admin.Models
{
    public class DepartmentUpdateAjaxViewModel
    {
        public DepartmentUpdateDto DepartmentUpdateDto { get; set; }

        public string DepartmentUpdatePartial { get; set; }

        public DepartmentDto DepartmentDto { get; set; }

    }
}
