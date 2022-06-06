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
    public class TicketMap : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {

            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.Title).IsRequired();
            builder.Property(a => a.Title).HasMaxLength(80);
            builder.Property(a => a.Description).IsRequired();



            builder.HasOne<Status>(a => a.Status).WithMany(c => c.Tickets).HasForeignKey(d => d.StatusId);
            builder.HasOne<User>(a => a.User).WithMany(c => c.Tickets).HasForeignKey(d => d.UserId);
            //builder.HasOne<Admin>(a => a.Admin).WithMany(c => c.Tickets).HasForeignKey(d => d.AdminId);

            builder.ToTable("Ticket");




        }
    }
}