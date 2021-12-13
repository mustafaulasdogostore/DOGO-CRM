using DogoCRM.Entities.Concrete.DTOS;
using DogoCRM.Shared.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogoCRM.Services.Abstract
{
    public interface IRequestService
    {
        Task<IDataResult<RequestDto>> Get(int userId);
        Task<IDataResult<RequestListDto>> GetAll();

        Task<IDataResult<RequestDto>> Add(RequestAddDto reguestAdddto);
        Task<IDataResult<RequestDto>> Update(RequestUpdateDto requestUpdateDto);
    }
}
