using DogoCRM.Shared.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogoCRM.Entities.Concrete.DTOS
{
    public class UserListDto : DtoGetBase
    {
        public IList<User> Users { get; set; }
    }
}
