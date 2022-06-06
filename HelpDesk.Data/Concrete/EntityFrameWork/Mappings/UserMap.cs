using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelpDesk.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelpDesk.Data.Concrete.EntityFrameWork.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.Name).IsRequired();
            builder.Property(a => a.Name).HasMaxLength(80);
            builder.Property(a => a.Email).HasMaxLength(80);
            builder.Property(a => a.Email).IsRequired();
            builder.Property(a => a.Email).HasColumnType("NVARCHAR(MAX)");
            builder.Property(a => a.Password).HasMaxLength(80);
            builder.Property(a => a.Password).IsRequired();
            builder.Property(a => a.Password).HasColumnType("NVARCHAR(MAX)");

            builder.HasOne<Company>(a => a.Company).WithMany(c => c.Users).HasForeignKey(d => d.CompanyId);

            //builder.HasOne<Role>(a => a.Roles).WithMany(c => c.Users).HasForeignKey(d => d.RoleId);
            

            builder.ToTable("User");


        }

    }
}
