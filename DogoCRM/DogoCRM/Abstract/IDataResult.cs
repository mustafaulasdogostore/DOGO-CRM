using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogoCRM.Shared.Abstract
{
    public interface IDataResult<out T>:IResult
    {
        public T Data { get;} //new DataResult<Request>(Result.Success,Request),new DataResult<IList><Request>>(Result.Status.Success,requestList);

    }
}
