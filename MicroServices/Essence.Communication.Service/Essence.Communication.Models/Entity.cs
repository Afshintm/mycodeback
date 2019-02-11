using System;
using System.Collections.Generic;
using System.Text;

namespace Essence.Communication.Models
{
    public interface IEntity
    {
        string Id { get; set; }
        DateTime CreateDate { get; set; }
    }

    public class Entity :IEntity
    {
        public Entity()
        {
            Id = Guid.NewGuid().ToString();
            CreateDate = DateTime.UtcNow;
        }
        public string Id { get; set; }

        //UTC time??
        public DateTime CreateDate { get; set; }
    }
     
}
