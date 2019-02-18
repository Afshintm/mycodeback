using Essence.Communication.Models;
using Essence.Communication.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;

namespace Essence.Communication.DbContexts.Configurations
{
    public class AccountUserConfig : IEntityTypeConfiguration<AccountUser>
    {
        public void Configure(EntityTypeBuilder<AccountUser> builder)
        {
            builder.ToTable("AccountUser");
            builder.HasKey(a => new { a.AccountId, a.UserId });
            builder.Ignore(a => a.Id);
        }

    } 

    
}
