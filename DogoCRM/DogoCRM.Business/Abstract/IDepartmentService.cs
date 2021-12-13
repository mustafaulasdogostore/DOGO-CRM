using DogoCRM.Entities.Concrete;
using DogoCRM.Entities.Concrete.DTOS;
using DogoCRM.Shared.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogoCRM.Services.Abstract
{
   public interface IDepartmentService
    {

   
        Task<IDataResult<DepartmentListDto>> GetAll();
        Task<IDataResult<DepartmentDto>> Get(string name);

        Task<IDataResult<DepartmentUpdateDto>> GetDepartmentUpdateDto(int departmentId);

        Task<IDataResult<DepartmentDto>> Add(DepartmentAddDto departmentAdddto);
        Task<IDataResult<DepartmentDto>> Update(DepartmentUpdateDto departmentUpdatedto);

        Task<IResult> Delete(int departmentId);

    }
}
