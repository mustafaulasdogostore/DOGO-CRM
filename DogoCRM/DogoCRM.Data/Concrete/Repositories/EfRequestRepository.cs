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
   public class EfRequestRepository: EfEntityRepositoryBase<Request>,IRequestRepository
    {
        public EfRequestRepository(DbContext context):base(context)
        {

        }
    }
}
