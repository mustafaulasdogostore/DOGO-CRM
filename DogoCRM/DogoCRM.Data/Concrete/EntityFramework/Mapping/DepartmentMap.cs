using DogoCRM.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogoCRM.Data.Concrete.EntityFramework.Mapping
{
    public class DepartmentMap : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();

            builder.Property(a => a.Name).HasMaxLength(30);
            builder.Property(a => a.Name).IsRequired();

            builder.Property(a => a.IsActive).IsRequired();

            builder.Property(a => a.IsDeleted).IsRequired();

            builder.Property(a => a.CreatedDate).IsRequired();
            builder.Property(a => a.ModifiedDate).IsRequired();

            builder.HasData(
             
                new Department 
                { Id=1,
                Name="Sales",
                IsActive=true,
                IsDeleted=false,
                CreatedDate=DateTime.Now,
                ModifiedDate=DateTime.Now
            
                },
                  new Department
                  {
                      Id = 2,
                      Name = "Accounting",
                      IsActive = true,
                      IsDeleted = false,
                      CreatedDate = DateTime.Now,
                      ModifiedDate = DateTime.Now

                  }
                  ,
                  new Department
                  {
                      Id = 3,
                      Name = "Design",
                      IsActive = true,
                      IsDeleted = false,
                      CreatedDate = DateTime.Now,
                      ModifiedDate = DateTime.Now

                  }
                  ,
                  new Department
                  {
                      Id = 4,
                      Name = "E-Commerce",
                      IsActive = true,
                      IsDeleted = false,
                      CreatedDate = DateTime.Now,
                      ModifiedDate = DateTime.Now

                  }
                );
       

            builder.ToTable("Departments");
        }
    }
}
