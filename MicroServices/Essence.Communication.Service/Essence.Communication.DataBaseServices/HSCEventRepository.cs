using Essence.Communication.DataBaseServices.Daos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Essence.Communication.DataBaseServices
{
    public interface IHSCEventRepository : IRepository<HSCEventDAO>
    {
        HSCEventDAO GetByEventId(string id);
    }
    public class HSCEventRepository : Repository<HSCEventDAO>, IHSCEventRepository
    {
        public HSCEventRepository(EventDbContext context) : base(context)
        {
            
        }
        public EventDbContext Essence { get => _context as EventDbContext; }
        public HSCEventDAO GetByEventId(string id)
        {
            return Essence.HSCEvent.FirstOrDefault(e => e.EventId.ToString() == id);
        }

    }
}
