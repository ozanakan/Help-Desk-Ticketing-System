using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelpDesk.Data.Concrete.EntityFrameWork.Mappings;
using HelpDesk.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace HelpDesk.Data.Concrete.EntityFrameWork.Contexts
{
    public class HelpDeskContext:DbContext
    {
       
        public DbSet<Company> Companies { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Role>  Roles{ get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<TicketAnswer> TicketAnswers { get; set; }
        public DbSet<UserView> UserViews { get; set; }
        public DbSet<UserCompanyView> UserCompanyViews { get; set; }
        public DbSet<RoleUser> RoleUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-PU7I8L5;database=HelpDesk;trusted_connection=true;Integrated Security=TRUE;MultipleActiveResultSets = true");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CompanyMap());
            modelBuilder.ApplyConfiguration(new PhotoMap());
            modelBuilder.ApplyConfiguration(new RoleMap());
            modelBuilder.ApplyConfiguration(new StatusMap());
            modelBuilder.ApplyConfiguration(new TicketMap());
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new TicketAnswerMap());
            modelBuilder.Entity<UserView>(eb =>
            {
                eb.HasNoKey();
                eb.ToView("UserView");
                eb.Property(v => v.Name).HasColumnName("Name");
            });
            modelBuilder.Entity<UserCompanyView>(eb =>
            {
                eb.HasNoKey();
                eb.ToView("UserCompanyView");
                eb.Property(v => v.Name).HasColumnName("Name");
            });
            //modelBuilder.ApplyConfiguration(new RoleUserMap());
            modelBuilder.Entity<User>().HasMany(x => x.Roles)
                .WithMany(x => x.Users)
                .UsingEntity<RoleUser>(
                    x => x.HasOne(x => x.Role)
                        .WithMany().HasForeignKey(x => x.RoleId),
                    x => x.HasOne(x => x.User)
                        .WithMany().HasForeignKey(x => x.UserId));
        }
    }
}
