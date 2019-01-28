using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Utilities.DataAccess
{
    public class DbContextBase<TContext> : DbContext where TContext : DbContext
    {
        static DbContextBase()
        {
            //Database.SetInitializer<TContext>(null);
        }


        public DbContextBase(DbContextOptions options) :
            base(options){}

        public new DbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }
    }
}
