using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogoCRM.Entities.Concrete
{
   public class User:IdentityUser<int>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public bool IsManager { get; set; }

        public bool IsActive { get; set; }

        public string Picture { get; set; }

        public int DepartmentId { get; set; }

        public virtual Department   Department { get; set; }
        public List<Request> Requests { get; set; }
    }
}
