using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogoCRM.Entities.Concrete.DTOS
{
  public  class RequestUpdateDto
    {

        [Required]
        public int Id { get; set; }

        [DisplayName("Title")]
        [Required(ErrorMessage = "{0} field can not be empty")]
        [MaxLength(150, ErrorMessage = "{0} must be max {1} length ")]
        [MinLength(5, ErrorMessage = "{0} must be {1} at least")]
        public string Title { get; set; }

        [DisplayName("Description")]
        [Required(ErrorMessage = "{0} field can not be empty")]
        [MaxLength(1000, ErrorMessage = "{0} must be max {1} length ")]
        [MinLength(5, ErrorMessage = "{0} must be {1} at least")]
        public string Description { get; set; }

        public string Picture { get; set; }

        [DisplayName("Importance Level")]
        [Required(ErrorMessage = "{0} Please select a severity level. ")]
        public int ImportanceLevel { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ModifiedDate{ get; set; }

        [DisplayName("Status")]
        [Required(ErrorMessage = "{0} Situation can not be empty ")]
        public string Status { get; set; }


        [DisplayName("Is Active ?")]
        [Required(ErrorMessage = "{0} Please select Delete situation ")]
        public bool IsActive { get; set; }



    }
}
