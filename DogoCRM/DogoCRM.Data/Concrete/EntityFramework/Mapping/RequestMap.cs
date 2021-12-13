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
    public class RequestMap : IEntityTypeConfiguration<Request>
    {
        public void Configure(EntityTypeBuilder<Request> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();

            builder.Property(a => a.Title).HasMaxLength(150);
            builder.Property(a => a.Title).IsRequired();

            builder.Property(a => a.Description).HasColumnType("NVARCHAR(MAX)");
            builder.Property(a => a.Description).IsRequired();

            builder.Property(a => a.Status).HasMaxLength(10);
            builder.Property(a => a.Status).IsRequired();

            builder.Property(a => a.IsActive).IsRequired();
            builder.Property(a => a.IsDeleted).IsRequired();

            builder.Property(a => a.CreatedDate).IsRequired();
            builder.Property(a => a.ModifiedDate).IsRequired();

            builder.Property(a => a.Picture).HasMaxLength(250);

            builder.HasOne<User>(a => a.User).WithMany(a => a.Requests).HasForeignKey(a => a.UserId);

            builder.ToTable("Requests");

        }
    }
}
