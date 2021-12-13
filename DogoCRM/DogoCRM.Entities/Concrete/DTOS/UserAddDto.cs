using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogoCRM.Entities.Concrete.DTOS
{
   public class UserAddDto
    {

        [DisplayName("First Name")]
        [Required(ErrorMessage = "{0} can not be empty")]
        [MaxLength(70, ErrorMessage = "{0} must be at max {1} length ")]
        [MinLength(3, ErrorMessage = "{0} must be at least {1} length ")]

        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        [Required(ErrorMessage = "{0} can not be empty")]
        [MaxLength(70, ErrorMessage = "{0} must be at max {1} length ")]
        [MinLength(3, ErrorMessage = "{0} must be at least {1} length ")]

        public string LastName { get; set; }
        [DisplayName("UserName")]
        [Required(ErrorMessage = "{0} can not be empty")]
        [MaxLength(70, ErrorMessage = "{0} must be at max {1} length ")]
        [MinLength(3, ErrorMessage = "{0} must be at least {1} length ")]

        public string UserName { get; set; }

        [DisplayName("Email")]
        [Required(ErrorMessage = "{0} can not be empty")]
        [MaxLength(70, ErrorMessage = "{0} must be at max {1} length ")]
        [MinLength(3, ErrorMessage = "{0} must be at least {1} length ")]


        public string Email { get; set; }

        [DisplayName("Password")]
        [Required(ErrorMessage = "{0} can not be empty")]
        [MaxLength(70, ErrorMessage = "{0} must be at max {1} length ")]
        [MinLength(6, ErrorMessage = "{0} must be at least {1} length ")]


        public string Password { get; set; }

        [DisplayName("Department")]
        [Required(ErrorMessage = "{0} can not be empty")]
        public int DepartmentId { get; set; }

        [DisplayName("Is Manager")]
        [Required(ErrorMessage = "{0} can not be empty")]
        public bool IsManager { get; set; }
        [DisplayName("Is Active")]
        [Required(ErrorMessage = "{0} can not be empty")]
        public bool IsActive { get; set; }

        [DisplayName("Picture")]
        [Required(ErrorMessage = "Please select a {0}")]
        [DataType(DataType.Upload)]
        public IFormFile PictureFile { get; set; }

        public string Picture { get; set; }


        public List<SelectListItem> DepartmentList { get; set; }

    }
}
