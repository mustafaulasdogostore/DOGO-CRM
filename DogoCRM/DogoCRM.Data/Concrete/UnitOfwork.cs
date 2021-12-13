using DogoCRM.Data.Abstract;
using DogoCRM.Data.Concrete.EntityFramework.Contexts;
using DogoCRM.Data.Concrete.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogoCRM.Data.Concrete
{
    public class UnitOfwork : IUnitOfwork
    {

        private readonly DogoDatabaseContext _context;
        private EfDepartmentRepository _efdepartmentRepository;
        private EfRequestRepository _efrequestRepository;

        public UnitOfwork(DogoDatabaseContext context)
        {
            _context = context;
        }

        public IRequestRepository Requests => _efrequestRepository ?? new EfRequestRepository(_context);

        public IDepartmentRepository Departments => _efdepartmentRepository ?? new EfDepartmentRepository(_context);

        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
