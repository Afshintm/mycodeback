using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Text;

namespace Essence.Communication.DbContexts
{
    public static class DbContextHelper
    {
        public static ValueConverter GetEnumValueConverter<T>() where T : IConvertible
        {
            return new ValueConverter<T, string>(
                v => v.ToString(),
                v => (T)Enum.Parse(typeof(T), v));
            );
        }

    }
}
