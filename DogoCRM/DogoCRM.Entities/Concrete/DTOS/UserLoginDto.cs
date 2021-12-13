using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogoCRM.Entities.Concrete.DTOS
{
   public class UserLoginDto
    {

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


        [DisplayName("Remember Me")]
        public bool Rememberme { get; set; }

    }
}
