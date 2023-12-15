using EventManagerService.Domain.Entities;
using EventManagerService.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EventManagerService.Infrastructure.Repository
{
    public class UserEventRepository : Repository<UserEvent>
    {
        public UserEventRepository(EventManagerDbContext dbContext) : base(dbContext) {}

        public override UserEvent Get(Func<UserEvent, bool> filter)
        {
            return dbSet.Include(e => e.RegisteredUsers).Include(e => e.Creator).Include(e => e.Categories).FirstOrDefault(filter);
        }

        public override IEnumerable<UserEvent> Where(Func<UserEvent, bool> filter)
        {
            return dbSet.Include(e => e.RegisteredUsers).Include(e => e.Creator).Include(e => e.Categories).Where(filter);
        }
    }
}
