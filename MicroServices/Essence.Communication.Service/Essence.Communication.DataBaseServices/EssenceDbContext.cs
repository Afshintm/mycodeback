using Essence.Communication.DataBaseServices.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Essence.Communication.DataBaseServices
{
    public class EssenceDbContext: DbContext
    {
        public EssenceDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<EssenceEvent> Events { get; set; }
    }
}
