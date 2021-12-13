using AutoMapper;
using DogoCRM.Entities.Concrete;
using DogoCRM.Entities.Concrete.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogoCRM.MVC.AutoMapper.Profiles
{
    public class UserProfile:Profile
    {
        public UserProfile()
        {
            CreateMap<UserAddDto, User>();

        }
    }
}
