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
    public class CommercialEventRepository : Repository<CommercialEvent>
    {
        public CommercialEventRepository(EventManagerDbContext dbContext) : base(dbContext) { }

        public override CommercialEvent Get(Func<CommercialEvent, bool> filter)
        {
            return dbSet.Include(e => e.RegisteredUsers)
                .Include(e => e.Creator)
                .Include(e => e.Categories)
                .FirstOrDefault(filter);
        }

        public override IEnumerable<CommercialEvent> Where(Func<CommercialEvent, bool> filter)
        {
            return dbSet.Include(e => e.RegisteredUsers)
                .Include(e => e.Creator)
                .Include(e => e.Categories)
                .Where(filter);
        }
    }
}
