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
    public class DepartmentManager : IDepartmentService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfwork _unitofwork;
        public DepartmentManager (IUnitOfwork unitofwork,IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }


        public async Task<IDataResult<DepartmentDto>> Add(DepartmentAddDto departmentAdddto)
        {
            var department = _mapper.Map<Department>(departmentAdddto);

          var addedDepartment=  await _unitofwork.Departments.AddSync(department);
            await _unitofwork.SaveAsync();

            return new DataResult<DepartmentDto>(ResultStatus.Success, $"{departmentAdddto.Name} has successfully added",new DepartmentDto { 
            Department=addedDepartment,
            ResultStatus=ResultStatus.Success,
             Message= $"{departmentAdddto.Name} has successfully added"
            });
           
        }
        public async Task<IDataResult<DepartmentDto>> Update(DepartmentUpdateDto departmentUpdatedto)
        {
            var oldDepartment = await _unitofwork.Departments.GetAsync(a => a.Id == departmentUpdatedto.Id);


            var department = _mapper.Map<DepartmentUpdateDto, Department>(departmentUpdatedto,oldDepartment);

            var updatedDepartment=  await _unitofwork.Departments.UpdateAsync(department);
       
            await _unitofwork.SaveAsync();

            return new DataResult<DepartmentDto>(ResultStatus.Success, $"{departmentUpdatedto.Name} has successfully added", new DepartmentDto
            {
                Department = updatedDepartment,
                ResultStatus = ResultStatus.Success,
                Message = $"{updatedDepartment.Name} has successfully Updated"
            });
        }
        public async Task<IResult> Delete(int departmentId)
        {
            //var department = _mapper.Map<Department>(departmendeleteDto);

            var department = await _unitofwork.Departments.GetAsync(a => a.Id == departmentId);

            if (department!=null)
            {
                await _unitofwork.Departments.DeleteAsync(department);
                await _unitofwork.SaveAsync();

                return new Result(ResultStatus.Success, "The department has successfully deleted.");

            }



            return new Result(ResultStatus.Error, "Somethink is went wrong");

          
        }

        public async Task<IDataResult<DepartmentListDto>> GetAll()
        {
            var deparments = await _unitofwork.Departments.GetAllAsync();
            if (deparments.Count > -1)
            {
                return new DataResult<DepartmentListDto>(ResultStatus.Success, new DepartmentListDto
                {
                    Departments=deparments,
                    ResultStatus = ResultStatus.Success
                

                });

            }
            return new DataResult<DepartmentListDto>(ResultStatus.Error, "There is no such a Request of list", new DepartmentListDto { 
            Departments=null,
            ResultStatus=ResultStatus.Error,
            Message= "There is no such a Request of list"

            });
        }

        public async Task<IDataResult<DepartmentDto>> Get(string name)
        {

            var department = await _unitofwork.Departments.GetAsync(a => a.Name == name);

            if (department!=null)
            {

                return new DataResult<DepartmentDto>(ResultStatus.Success, new DepartmentDto
                {

                    Department = department,
                    ResultStatus = ResultStatus.Success
                });
            }

            return new DataResult<DepartmentDto>(ResultStatus.Error, "There is no such e Department", new DepartmentDto
            {
                Department = department,
                ResultStatus = ResultStatus.Error,
                Message = "There is no such e Department"


            });
        }

        public async Task<IDataResult<DepartmentUpdateDto>> GetDepartmentUpdateDto(int departmentId)
        {  
            var resultbool = await _unitofwork.Departments.AnyAsync(c => c.Id == departmentId);

            if (resultbool)
            {
                var department = await _unitofwork.Departments.GetAsync(a => a.Id == departmentId);

                var departmentUpadtedDto = _mapper.Map<DepartmentUpdateDto>(department);

                return new DataResult<DepartmentUpdateDto>(ResultStatus.Success, departmentUpadtedDto);
            }
            else
            {

                return new DataResult<DepartmentUpdateDto>(ResultStatus.Error,"There is no such a Department", null);

            }
        }
    }
}
