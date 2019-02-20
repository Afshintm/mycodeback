using Essence.Communication.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Text;

namespace Essence.Communication.DbContexts
{
    public static class DbContextHelper
    {
        public const string ReadOnlyEntityMsg = "Try to modify one of the readonly entities: UserReference";
        public static ValueConverter GetEnumValueConverter<T>() where T : IConvertible
        {
            return new ValueConverter<T, string>(
                v => v.ToString(),
                v => (T)Enum.Parse(typeof(T), v));
            
        }
    }
}
