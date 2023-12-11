using EventManagerService.Domain.Entities;
using EventManagerService.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagerService.Infrastructure.Repository
{
    public class UserRepository : Repository<User>
    {
        public UserRepository(EventManagerDbContext dbContext) : base(dbContext) { }

        public override User Get(Func<User, bool> filter)
        {
            return dbSet.Include(u => u.UserEvents).Include(u => u.SignedEvents).FirstOrDefault(filter);
        }

        public override IEnumerable<User> Where(Func<User, bool> filter)
        {
            return dbSet.Include(u => u.UserEvents).Include(u => u.SignedEvents).Where(filter);
        }
    }
}
