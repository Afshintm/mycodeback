using Essence.Communication.DataBaseServices.Daos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Essence.Communication.DataBaseServices
{
    public interface IEventRepository : IRepository<EssenceEvent>
    { 
       
    }
    public class EventRepository : Repository<EssenceEvent>, IEventRepository
    {
        public EventRepository(EventDbContext context) : base(context)
        {
            
        }
        public EventDbContext Essence { get => _context as EventDbContext; }


    }
}
