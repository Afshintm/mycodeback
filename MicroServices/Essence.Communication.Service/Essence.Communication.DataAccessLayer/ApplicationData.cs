using Essence.Communication.DataAccessLayer.Configurations;
using Essence.Communication.Models;
using Essence.Communication.Models.Dtos;
using Essence.Communication.Models.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System;

namespace Essence.Communication.DataAccessLayer
{
    public class ApplicationData 
    {
        private Repository<EssenceEventObjectStructure> venderEventRepository;
        private Repository<EventBase> eventRepository;
        private DbContext _context;
        public ApplicationData(DbContext context)
        {
            //TODO: regiest repostory
            venderEventRepository = new Repository<EssenceEventObjectStructure>(context);
            eventRepository = new Repository<EventBase>(context);

            _context = context;
        }

        public void AddVendorEvent(EssenceEventObjectStructure vendorEvent)
        {
            venderEventRepository.Add(vendorEvent);
            _context.SaveChanges();
        }


        public void AddNewEvent(EventBase vendorEvent)
        {
            eventRepository.Add(vendorEvent);
            _context.SaveChanges();
        }

        public EventBase GetEvent(string id)
        {
            return eventRepository.Get(id); 
        }

        public void Complete()
        {
            _context.SaveChanges();
        }

    }
}
