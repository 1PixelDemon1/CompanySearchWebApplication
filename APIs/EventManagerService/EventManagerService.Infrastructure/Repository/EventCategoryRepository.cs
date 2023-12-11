using EventManagerService.Domain.Entities;
using EventManagerService.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;


namespace EventManagerService.Infrastructure.Repository
{
    public class EventCategoryRepository : Repository<EventCategory>
    {
        public EventCategoryRepository(EventManagerDbContext dbContext) : base(dbContext) { }

        public override EventCategory Get(Func<EventCategory, bool> filter)
        {
            return dbSet.Include(e => e.Events).FirstOrDefault(filter);
        }

        public override IEnumerable<EventCategory> Where(Func<EventCategory, bool> filter)
        {
            return dbSet.Include(e => e.Events).Where(filter);
        }
    }
}
