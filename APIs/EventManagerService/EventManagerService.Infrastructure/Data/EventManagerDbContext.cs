using EventManagerService.Domain.Entities;
using EventManagerService.Domain.Entities.BaseEntities;
using Microsoft.EntityFrameworkCore;
using System.Collections;
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

            SeedData(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        protected void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Age = 21,
                    Email = "testmail@gmail.com",
                    Gender = User.Genders.MALE,
                    Name = "Анатолий",
                    PhoneNumber = "+71234567890"
                },
                new User
                {
                    Id = 2,
                    Age = 45,
                    Email = "testmail1@gmail.com",
                    Gender = User.Genders.MALE,
                    Name = "Евгений",
                    PhoneNumber = "+71234567891"
                },
                new User
                {
                    Id = 3,
                    Age = 32,
                    Email = "testmail2@gmail.com",
                    Gender = User.Genders.FEMALE,
                    Name = "Анастасия",
                    PhoneNumber = "+71234567892"
                },
                new User
                {
                    Id = 4,
                    Age = 15,
                    Email = "testmail3@gmail.com",
                    Gender = User.Genders.FEMALE,
                    Name = "Валентина",
                    PhoneNumber = "+71234567893"
                });
            modelBuilder.Entity<CommercialUser>().HasData(
                new CommercialUser
                {
                    Id = 5,
                    Name = "VIMers corp",
                    PersonalAccount = "70ББ000584"
                },
                new CommercialUser
                {
                    Id = 6,
                    Name = "Банк Пеньков",
                    PersonalAccount = "70ББ000585"
                });
            modelBuilder.Entity<EventCategory>().HasData(
                new
                {
                    Id = 1,
                    Name = "Фестиваль",
                },
                new
                {
                    Id = 2,
                    Name = "Фестиваль волонтеров",
                    ParentCategoryId = 1
                },
                new
                {
                    Id = 3,
                    Name = "Концерт"
                },
                new
                {
                    Id = 4,
                    Name = "Праздничный концерт",
                    ParentCategoryId = 3
                },
                new
                {
                    Id = 5,
                    Name = "Поход в кино",
                },
                new
                {
                    Id = 6,
                    Name = "Конференция",
                }
            );
            modelBuilder.Entity<UserEvent>().HasData(
                new
                {
                    Id = 1,
                    CreateTime = DateTime.Now,
                    UpdateTime = DateTime.Now,
                    DeadLine = DateTime.Now.AddDays(10),
                    Description = "Посещение кинотеатра Джаз.Синема для просмотра фильма \"Человек паук 6\"",
                    EventDateTime = DateTime.Now.AddDays(11),
                    EventDuration = TimeSpan.FromMinutes(176),
                    GenderRules = GenderRules.ALL,
                    MinAge = 16,
                    MaxAge = -1,
                    MinUsers = 1,
                    MaxUsers = 80,
                    Location = "г.Магнитогорск ул.Герцена д.6",
                    CreatorId = 1,
                },
                new
                {
                    Id = 2,
                    CreateTime = DateTime.Now,
                    UpdateTime = DateTime.Now,
                    DeadLine = DateTime.Now.AddDays(10),
                    Description = "Посещение кинотеатра Джаз.Синема для просмотра фильма \"Человек паук 6\", посещение фестиваля после",
                    EventDateTime = DateTime.Now.AddDays(11),
                    EventDuration = TimeSpan.FromMinutes(576),
                    GenderRules = GenderRules.ALL,
                    MinAge = 16,
                    MaxAge = -1,
                    MinUsers = 1,
                    MaxUsers = 80,
                    Location = "г.Магнитогорск пр.Ленина д.72",
                    CreatorId = 3,
                });
            modelBuilder.Entity<CommercialEvent>().HasData(
                new
                {
                    Id = 3,
                    CreateTime = DateTime.Now,
                    UpdateTime = DateTime.Now,
                    DeadLine = DateTime.Now.AddDays(5),
                    Description = "Проведение публичной конференции",
                    EventDateTime = DateTime.Now.AddDays(6),
                    EventDuration = TimeSpan.FromMinutes(120),
                    GenderRules = GenderRules.ALL,
                    MinAge = 18,
                    MaxAge = -1,
                    MinUsers = 20,
                    MaxUsers = -1,
                    Location = "г.Магнитогорск пр.Ленина д.130",
                    CreatorId = 5,
                    Price = new Decimal(0),
                },
                new
                {
                    Id = 4,
                    CreateTime = DateTime.Now,
                    UpdateTime = DateTime.Now,
                    DeadLine = DateTime.Now.AddDays(15),
                    Description = "Проведение IT - конференции",
                    EventDateTime = DateTime.Now.AddDays(16),
                    EventDuration = TimeSpan.FromMinutes(150),
                    GenderRules = GenderRules.ALL,
                    MinAge = 18,
                    MaxAge = -1,
                    MinUsers = 0,
                    MaxUsers = -1,
                    Location = "г.Магнитогорск пр.Ленина д.130",
                    CreatorId = 6,
                    Price = new Decimal(0)
                });
        }
    }
}
