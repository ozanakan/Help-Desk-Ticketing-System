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
    public class PhotoMap : IEntityTypeConfiguration<Photo>
    {
        public void Configure(EntityTypeBuilder<Photo> builder)
        {
            {
                builder.HasKey(a => a.Id);
                builder.Property(a => a.Id).ValueGeneratedOnAdd();
                builder.Property(a => a.Name).IsRequired();
                builder.Property(a => a.Name).HasMaxLength(80);

                builder.HasOne<Ticket>(a => a.Ticket).WithMany(c => c.Photos).HasForeignKey(d => d.TicketId);
                builder.ToTable("Photo");

            }
        }
    }
}
