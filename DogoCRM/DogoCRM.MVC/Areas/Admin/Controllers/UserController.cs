using AutoMapper;
using DogoCRM.Entities.Concrete;
using DogoCRM.Entities.Concrete.DTOS;
using DogoCRM.MVC.Areas.Admin.Models;
using DogoCRM.Services.Abstract;
using DogoCRM.Shared.Concrete;
using DogoCRM.Shared.Utilities.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace DogoCRM.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IWebHostEnvironment _env;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _imapper;
        private readonly IDepartmentService _departmentService;

        private readonly SignInManager<User> _signInManager;
        public UserController(UserManager<User> userManager, IWebHostEnvironment env,IMapper mapper, IDepartmentService departmentService, SignInManager<User>  signInManager)
        {
            _userManager = userManager;
            _env = env;
            _imapper = mapper;
            _departmentService = departmentService;
            _signInManager = signInManager;
        }

        [Authorize(Roles ="Admin")]
        public async Task< IActionResult> Index()
        {
            var users = await _userManager.Users.Where(a=>a.IsActive).Include(a=>a.Department).ToListAsync();

            return View(new UserListDto { 
            
                Users=users,
                ResultStatus=ResultStatus.Success
            
            
            });
        }

        [HttpGet]
        public ActionResult Login()
        {

            return View("UserLogin");
        }

        [HttpPost]
        public async Task< ActionResult> Login( UserLoginDto userLoginDto)
        {
            if (ModelState.IsValid)
            {

                var user = await _userManager.FindByEmailAsync(userLoginDto.Email);
                if (user!=null)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, userLoginDto.Password, userLoginDto.Rememberme, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        //şifre yanlış
                        ModelState.AddModelError("", "Password or Email is incorrect");
                        return View("UserLogin");
                    }

                }
                else
                {
                    ModelState.AddModelError("", "There is no such a email");
                    return View("UserLogin");
                }
            }

            else
            {
                return View("UserLogin");
            }

        
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> LogOut()
        {


            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home", new { Area = "" });
        }


        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Add()
        {

            var result = _departmentService.GetAll();

            if (result.Result.ResultStatus==ResultStatus.Success)
            {
                var departments = result.Result.Data.Departments;

                UserAddDto model = new UserAddDto()
                {
                    DepartmentList = departments.Select(a => new SelectListItem

                    {
                        Value = a.Id.ToString(),
                        Text = $"{a.Name}"

                    }).ToList()
                };

                return PartialView("_UserAddPartial",model);
            }

            ////var departments =  new DepartmentListDto { Departments=_departmentService.GetAll()}
            //UserAddDto model = new UserAddDto()
            //{
            //   DepartmentList=departments.
            //};

            return PartialView("_UserAddPartial");
        }

        [HttpPost]
        public async Task< IActionResult> Add(UserAddDto userAddDto)
        {
            if (ModelState.IsValid)
            {
                userAddDto.Picture = await ImageUpload(userAddDto);
                var user = _imapper.Map<User>(userAddDto);
                var result = await _userManager.CreateAsync(user, userAddDto.Password);
                if (result.Succeeded)
                {
                    var userAddAjaxModel = JsonSerializer.Serialize(new UserAddAjaxViewModel
                    {
                        UserDto=
                        new UserDto { 
                            ResultStatus = ResultStatus.Success, Message =$"{user.UserName} user has successfully created.",
                              User=user
                                     },
                        UserAddPartial=await this.RenderViewToStringAsync("_UserAddPartial",userAddDto)

                    });

                    return Json(userAddAjaxModel);
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }

                    var useraddAjaxerrorModel = JsonSerializer.Serialize(new UserAddAjaxViewModel { 
                    
                        UserAddDto=userAddDto,
                        UserAddPartial=await this.RenderViewToStringAsync("_UserAddPartial",userAddDto)
                    
                    
                    });

                    return Json(useraddAjaxerrorModel);
                }
            }
            //if model is valid
            var useraddAjaxerrorModelstate = JsonSerializer.Serialize(new UserAddAjaxViewModel
            {

                UserAddDto = userAddDto,
                UserAddPartial = await this.RenderViewToStringAsync("_UserAddPartial", userAddDto)


            });
            return Json(useraddAjaxerrorModelstate);
        }

        public async Task<string> ImageUpload(UserAddDto userAddDto)
        {
            //   ~/img/user/ulas.picture

            string wwwroot = _env.WebRootPath;
            //ulas
            //string fileName = Path.GetFileNameWithoutExtension(userAddDto.Picture.FileName);
            //jpg,png
            string fileExtension = Path.GetExtension(userAddDto.PictureFile.FileName);
            DateTime dateTime = DateTime.Now;
            string fileName = $"{userAddDto.UserName}_{dateTime.FullDateAndTimeStringWithUnderScore()}{fileExtension}";
            var path = Path.Combine($"{wwwroot}/img", fileName);
            await using (var stream=new FileStream(path,FileMode.Create)) {

                await userAddDto.PictureFile.CopyToAsync(stream);
             
            }

            return fileName; //ulas.png_587_5_36_12_3_10_2021.png  çağırmak için ~/img/user.picture
        }
    }
}
