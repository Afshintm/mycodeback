using Essence.Communication.DataBaseServices.Daos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Essence.Communication.DataBaseServices
{
    public interface IEssenceEventRepository : IRepository<EssenceEventDAO>
    { 
       
    }
    public class EssenceEventRepository : Repository<EssenceEventDAO>, IEssenceEventRepository
    {
        public EssenceEventRepository(EventDbContext context) : base(context)
        {
            
        }
        public EventDbContext Essence { get => _context as EventDbContext; }


    }
}
