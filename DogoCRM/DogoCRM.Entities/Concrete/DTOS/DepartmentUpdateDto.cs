using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogoCRM.Entities.Concrete.DTOS
{
   public class DepartmentUpdateDto
    {
        [Required]
        public int Id { get; set; }

        [DisplayName("Department Name")]
        [Required(ErrorMessage = "{0} can not be empty")]
        [MaxLength(70, ErrorMessage = "{0} must be at least {1} length ")]
        public string Name { get; set; }

        [DisplayName("Is Active ?")]
        [Required(ErrorMessage = "{0} can not be empty")]
        public bool IsActive { get; set; }
    }
}
