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
   public class RequestProfile:Profile
    {
        public RequestProfile()
        {
            CreateMap<RequestAddDto, Request>();
            CreateMap<RequestUpdateDto, Request>();


        }
    }
}
