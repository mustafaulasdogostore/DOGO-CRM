using DogoCRM.Data.Abstract;
using DogoCRM.Data.Concrete;
using DogoCRM.Data.Concrete.EntityFramework.Contexts;
using DogoCRM.Entities.Concrete;
using DogoCRM.Services.Abstract;
using DogoCRM.Services.Concrete;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogoCRM.Services.Extensions
{
  public static  class ServiceCollectionExtensions
    {
        public static IServiceCollection LoadMyService(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<DogoDatabaseContext>();
            serviceCollection.AddIdentity<User, Role>(options=> {
                //user password options
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 5;
                options.Password.RequiredUniqueChars = 0;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                //username and email options
                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = true;




            }).AddEntityFrameworkStores<DogoDatabaseContext>();
            serviceCollection.AddScoped<IUnitOfwork, UnitOfwork>();
            serviceCollection.AddScoped<IDepartmentService, DepartmentManager>();
            serviceCollection.AddScoped<IRequestService, RequestManager>();

            return serviceCollection;
        }
    }
}
