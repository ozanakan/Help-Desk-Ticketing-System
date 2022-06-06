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
    public class TicketAnswerMap : IEntityTypeConfiguration<TicketAnswer>
    {
        public void Configure(EntityTypeBuilder<TicketAnswer> builder)
        {

            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();

            builder.HasOne<Ticket>(a => a.Ticket).WithMany(c => c.TicketAnswer).HasForeignKey(d => d.TicketId);

            builder.ToTable("TicketAnswer");
        }
    }
}