using DogoCRM.Shared.Abstract;
using DogoCRM.Shared.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogoCRM.Entities.Concrete.DTOS
{
    public class RequestListDto:DtoGetBase
    {
        public IList<Request> Requests { get; set; }
   
    }
}
