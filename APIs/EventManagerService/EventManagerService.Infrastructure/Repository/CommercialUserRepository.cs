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
    public class CommercialUserRepository : Repository<CommercialUser>
    {
        public CommercialUserRepository(EventManagerDbContext dbContext) : base(dbContext) { }

        public override CommercialUser Get(Func<CommercialUser, bool> filter)
        {
            return dbSet.Include(u => u.CommercialEvents).FirstOrDefault(filter);
        }

        public override IEnumerable<CommercialUser> Where(Func<CommercialUser, bool> filter)
        {
            return dbSet.Include(u => u.CommercialEvents).Where(filter);
        }
    }
}
