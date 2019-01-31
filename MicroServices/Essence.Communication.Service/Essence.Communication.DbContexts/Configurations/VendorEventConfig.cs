using System.Linq;
using Essence.Communication.Models.Dtos;
using Essence.Communication.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace Essence.Communication.DbContexts.Configurations
{
    //TODO: change essence event to vender event
    public class VendorEventConfig : IEntityTypeConfiguration<EssenceEventObjectStructure>
    {
        public void Configure(EntityTypeBuilder<EssenceEventObjectStructure> builder)
        {
            builder.HasKey(h => h.Id)
                .HasName("PK_EssenceEvent_Id");

            //Default value
            builder.Property(h => h.Id)
                .HasDefaultValue(Guid.NewGuid().ToString())
                .IsRequired();

            builder.Property(h => h.CreateDate)
                .HasDefaultValue(DateTime.UtcNow)
                .IsRequired();

            //convert json obj into string
            var jsonConverter = new ValueConverter<JObject, string>(
                v => v.ToString(),
                v =>JObject.Parse(v)
            );
            builder.OwnsOne(h => h.Event).Property(a => a.Details).HasConversion(jsonConverter);

            //convert enum into string
            var vendorTypeConverter = new ValueConverter<Vendor, string>(
                v => v.ToString(),
                v => (Vendor)Enum.Parse(typeof(Vendor), v));

            builder.Property(h => h.Vendor).HasConversion(vendorTypeConverter);

            //convert id list into csv string
            var idsStringConverter = new ValueConverter<List<string>, string>(
                v => string.Join(',', v.ToArray()),
                v => v.Split(',', StringSplitOptions.None).ToList());
            builder.Property(h => h.Ids).HasConversion(idsStringConverter);
            //value object
            builder.OwnsOne(e => e.Event);
            builder.OwnsOne(e => e.Event).OwnsOne(b => b.Location);
            builder.OwnsOne(e => e.Event).Property(a => a.Code).IsRequired();
        }
    }
}
