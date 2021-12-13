using DogoCRM.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DogoCRM.Shared.Concrete;
using DogoCRM.Entities.Concrete.DTOS;
using DogoCRM.MVC.Areas.Admin.Models;
using DogoCRM.Shared.Utilities.Extensions;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization;

namespace DogoCRM.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }
        public async Task<IActionResult> Index()
        {
            var departments = await _departmentService.GetAll();


            return View(departments.Data);


        }

        [HttpGet]
        public IActionResult Add()
        {

            return PartialView("_DepartmentAddPartial");
        }

        [HttpPost]
        public async Task<IActionResult> Add(DepartmentAddDto departmentAddDto)
        {
            if (ModelState.IsValid)
            {
                var department = _departmentService.Get(departmentAddDto.Name);

                if (department.Result.ResultStatus == ResultStatus.Success)
                {
                    ModelState.AddModelError("Name", $"There is already a {departmentAddDto.Name}");

                    var departmentAddAjaxErrorModel2 = JsonSerializer.Serialize(new DepartmentAddAjaxViewModel
                    {

                        DepartmentAddPartial = await this.RenderViewToStringAsync("_DepartmentAddPartial", departmentAddDto)
                        //DepartmentAddDto=departmentAddDto

                    });

                    return Json(departmentAddAjaxErrorModel2);
                }
                else
                {

                    var result = await _departmentService.Add(departmentAddDto);
                    if (result.ResultStatus == ResultStatus.Success)
                    {
                        var departmentAddAjaxModel = JsonSerializer.Serialize(new DepartmentAddAjaxViewModel
                        {
                            DepartmentDto = result.Data,
                            DepartmentAddPartial = await this.RenderViewToStringAsync("_DepartmentAddPartial", departmentAddDto)

                        });

                        return Json(departmentAddAjaxModel);
                    }


                }



            }
            var departmentAddAjaxErrorModel = JsonSerializer.Serialize(new DepartmentAddAjaxViewModel
            {

                DepartmentAddPartial = await this.RenderViewToStringAsync("_DepartmentAddPartial", departmentAddDto)
                //DepartmentAddDto=departmentAddDto

            });

            return Json(departmentAddAjaxErrorModel);

        }


        [HttpPost]
        public async Task<JsonResult> Delete(int departmentId)
        {
            var result = await _departmentService.Delete(departmentId);

            var ajaxResult = JsonSerializer.Serialize(result);

            return Json(ajaxResult);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int departmentId)
        {
            var result = await _departmentService.GetDepartmentUpdateDto(departmentId);

            if (result.ResultStatus==ResultStatus.Success)
            {

                return PartialView("_DepartmentUpdatePartial", result.Data);
            }
            else
            {
                return NotFound();
            }

        }
        [HttpPost]
        public async Task<IActionResult>Update(DepartmentUpdateDto departmentUpdateDto)
        {

            if (ModelState.IsValid)
            {
                var result = await _departmentService.Update(departmentUpdateDto);

                if (result.ResultStatus==ResultStatus.Success)
                {
                    var departmentUpdateAjaxModel = JsonSerializer.Serialize(new DepartmentUpdateAjaxViewModel
                    {
                        DepartmentDto=result.Data,
                        DepartmentUpdatePartial= await this.RenderViewToStringAsync("_DepartmentUpdatePartial",departmentUpdateDto)

                    });

                    return Json(departmentUpdateAjaxModel);
                }

            }

            var departmentUpdateErrorAjaxModel = JsonSerializer.Serialize(new DepartmentUpdateAjaxViewModel
            {
                
                DepartmentUpdatePartial = await this.RenderViewToStringAsync("_DepartmentUpdatePartial", departmentUpdateDto)

            });

            return Json(departmentUpdateErrorAjaxModel);



        }
    }
}
