using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Essence.Communication.UnitTests
{
    public static class EFTestInMemoryHelper
    {
        const string inMemorySource = ":memory:";
            
        public static DbContextOptions<T> CreateContextOptions<T> () where T: DbContext
        {
            //create connectionstring 
            var connStrBuilder = new SqliteConnectionStringBuilder { DataSource = inMemorySource };
            var connString = connStrBuilder.ConnectionString;

            //create connection
            var connection = new SqliteConnection(connString);

            //create dbcontext builder
            var builder = new DbContextOptionsBuilder<T>();
            builder.UseSqlite(connection);
            return builder.Options;
        }
    }
}
