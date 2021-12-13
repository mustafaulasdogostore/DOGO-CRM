using AutoMapper;
using DogoCRM.Data.Abstract;
using DogoCRM.Entities.Concrete;
using DogoCRM.Entities.Concrete.DTOS;
using DogoCRM.Services.Abstract;
using DogoCRM.Shared.Abstract;
using DogoCRM.Shared.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogoCRM.Services.Concrete
{
    public class RequestManager : IRequestService
    {
        private readonly IUnitOfwork _unitofwork;

        private readonly IMapper _mapper;
        public RequestManager(IUnitOfwork unitOfwork,IMapper mapper)
        {
            _unitofwork = unitOfwork;
            _mapper = mapper;
        }
 

        public async Task<IDataResult<RequestDto>> Get(int userId)
        {
            var request = await _unitofwork.Requests.GetAsync(a => a.UserId == userId,a=>a.User);
            if (request!=null)
            {

                return new DataResult<RequestDto>(ResultStatus.Success,
                    new RequestDto { 
                    Request=request,
                    ResultStatus=ResultStatus.Success
                    
                    });
            }
            return new DataResult<RequestDto>(ResultStatus.Error, "There is no such a Request", new RequestDto
            {
               Request=request,
                ResultStatus = ResultStatus.Error,
                Message = "There is no such a Request"

            });
        }

        public async Task<IDataResult<RequestListDto>> GetAll()
        {
            var requests = await _unitofwork.Requests.GetAllAsync(null,a=>a.User);
            if (requests.Count>-1)
            {
                return new DataResult<RequestListDto>(ResultStatus.Success, new RequestListDto
                {
                    Requests=requests,
                    ResultStatus=ResultStatus.Success
                    
                   
                });

            }
            return new DataResult<RequestListDto>(ResultStatus.Error, "There is no such a Request of list", new RequestListDto
            {
                Requests = null,
                ResultStatus = ResultStatus.Error,
                Message = "There is no such a Request of list"

            });
        }

        public async Task<IDataResult<RequestDto>> Add(RequestAddDto reguestAdddto)
        {
            var request = _mapper.Map<Request>(reguestAdddto);

            //burayı değiştir
            request.UserId = 1;
           var addedRequest=  await _unitofwork.Requests.AddSync(request);

            await _unitofwork.SaveAsync();


            return new  DataResult<RequestDto>(ResultStatus.Success, $"{reguestAdddto.Title} has successfully updated", new RequestDto
            {
                Request = addedRequest,
                ResultStatus = ResultStatus.Success,
                Message = $"{addedRequest.Title} has successfully added"

            });


        }
        public async Task<IDataResult<RequestDto>> Update(RequestUpdateDto requestUpdateDto)
        {
            var request = _mapper.Map<Request>(requestUpdateDto);

            request.ModifiedDate = DateTime.Now;

            var updatedRequest=  await _unitofwork.Requests.UpdateAsync(request);

            await _unitofwork.SaveAsync();


            return new DataResult<RequestDto>(ResultStatus.Success, $"{requestUpdateDto.Title} has successfully updated",new RequestDto { 
            Request=updatedRequest,
            ResultStatus=ResultStatus.Success,
            Message= $"{requestUpdateDto.Title} has successfully updated"

            });
        }
    }
}
