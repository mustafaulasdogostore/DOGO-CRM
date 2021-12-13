using AutoMapper;
using DogoCRM.Entities.Concrete;
using DogoCRM.Entities.Concrete.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogoCRM.Services.AutoMapper.Profiles
{
   public class DepartmenProfile:Profile
    {
        public DepartmenProfile()
        {
            CreateMap<DepartmentAddDto, Department>();
            CreateMap<DepartmentUpdateDto, Department>();
            CreateMap<Department, DepartmentUpdateDto>();
        }
    }
}
