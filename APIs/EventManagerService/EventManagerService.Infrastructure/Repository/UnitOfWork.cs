using EventManagerService.Application.Interfaces;
using EventManagerService.Domain.Entities;
using EventManagerService.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagerService.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EventManagerDbContext _dbContext;

        public IRepository<User> Users { get; set; }
        public IRepository<CommercialUser> CommercialUsers { get; set; }
        public IRepository<UserEvent> UserEvents { get; set; }
        public IRepository<CommercialEvent> CommercialEvents { get; set; }
        public IRepository<EventCategory> Categories { get; set; }

        public UnitOfWork(EventManagerDbContext dbContext)
        {
            _dbContext = dbContext;
            Users = new UserRepository(_dbContext);
            CommercialUsers = new CommercialUserRepository(_dbContext);
            UserEvents = new UserEventRepository(_dbContext);
            CommercialEvents = new CommercialEventRepository(_dbContext);
            Categories = new EventCategoryRepository(_dbContext);
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
