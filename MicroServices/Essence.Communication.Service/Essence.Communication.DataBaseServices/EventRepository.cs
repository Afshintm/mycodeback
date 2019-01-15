using Essence.Communication.DataBaseServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Essence.Communication.DataBaseServices
{
    public interface IEventRepository : IRepository<EssenceEvent>
    {
        EssenceEvent GetByCode(int code);
    }
    public class EventRepository : Repository<EssenceEvent>, IEventRepository
    {
        public EventRepository(EssenceDbContext context) : base(context)
        {
            
        }

        public EssenceEvent GetByCode(int code)
        {
            return Essence.Events.FirstOrDefault(x => x.Code == code);
        }

        public EssenceDbContext Essence { get => _context as EssenceDbContext; }
    }
}
