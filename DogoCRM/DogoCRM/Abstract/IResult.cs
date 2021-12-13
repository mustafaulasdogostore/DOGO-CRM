using DogoCRM.Shared.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogoCRM.Shared.Abstract
{
   public interface IResult
    {

        public ResultStatus  ResultStatus { get;  }

        public string Message { get; }


        public Exception Exception { get; }
    }
}
