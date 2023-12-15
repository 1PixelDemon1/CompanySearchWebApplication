using EventManagerService.Domain.Entities;
using EventManagerService.Domain.Entities.BaseEntities;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace EventManagerService.Infrastructure.Data
{
    public class EventManagerDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<CommercialUser> CommercialUsers { get; set; }
        public DbSet<UserEvent> UserEvents { get; set; }
        public DbSet<CommercialEvent> CommercialEvents { get; set; }
        public DbSet<EventCategory> EventCategories { get; set; }

        public EventManagerDbContext(DbContextOptions<EventManagerDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Table-per-type configuration
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<CommercialUser>().ToTable("CommercialUsers");
            modelBuilder.Entity<UserEvent>().ToTable("UserEvents");
            modelBuilder.Entity<CommercialEvent>().ToTable("CommercialEvents");

            modelBuilder.Entity<UserEvent>().HasOne(ue => ue.Creator).WithMany(u => u.UserEvents);
            modelBuilder.Entity<CommercialEvent>().HasOne(ce => ce.Creator).WithMany(cu => cu.CommercialEvents);
            modelBuilder.Entity<EventCategory>().HasMany(c => c.ChildCategories).WithOne(cc => cc.ParentCategory);

            modelBuilder.Entity<UserEvent>().Property(e => e.GenderRules).HasConversion<int>();
            modelBuilder.Entity<CommercialEvent>().Property(e => e.GenderRules).HasConversion<int>();
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
