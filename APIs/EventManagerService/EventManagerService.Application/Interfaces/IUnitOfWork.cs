using EventManagerService.Domain.Entities;

namespace EventManagerService.Application.Interfaces
{
    public interface IUnitOfWork
    {
        public IRepository<User> Users {get; set;}
        public IRepository<CommercialUser> CommercialUsers {get; set;}
        
        public IRepository<UserEvent> UserEvents { get; set; }
        public IRepository<CommercialEvent> CommercialEvents { get; set; }

        public IRepository<EventCategory> Categories { get; set; }

        public void SaveChanges();

    }
}
