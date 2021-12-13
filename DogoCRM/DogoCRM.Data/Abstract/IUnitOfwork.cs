using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogoCRM.Data.Abstract
{
    public interface IUnitOfwork:IAsyncDisposable
    {
        IRequestRepository Requests { get; }

        IDepartmentRepository Departments { get; }


        Task<int> SaveAsync();
    }
}
