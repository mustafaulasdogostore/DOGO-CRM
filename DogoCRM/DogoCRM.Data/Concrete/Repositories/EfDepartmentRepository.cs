using DogoCRM.Data.Abstract;
using DogoCRM.Entities.Concrete;
using DogoCRM.Shared.Concrete.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogoCRM.Data.Concrete.Repositories
{
   public class EfDepartmentRepository: EfEntityRepositoryBase<Department> ,IDepartmentRepository
    {
        public EfDepartmentRepository(DbContext context):base(context)
        {

        }
    }
}
