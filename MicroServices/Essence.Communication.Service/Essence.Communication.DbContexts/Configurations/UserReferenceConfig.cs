using Essence.Communication.Models;
using Essence.Communication.Models.Enums;
using Essence.Communication.Models.IdentityModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;

namespace Essence.Communication.DbContexts.Configurations
{
    public class UserReferenceConfig : IEntityTypeConfiguration<UserReference>
    {
        public void Configure(EntityTypeBuilder<UserReference> builder)
        {
            builder.ToTable("User", "Identity");
            builder.HasKey(a =>  a.Id );
            builder.Property(x => x.UserName).HasColumnName("UserName").HasMaxLength(256); 
            builder.Property(x => x.UserType).HasColumnName("UserType");
            builder.Property(x => x.Email).HasColumnName("Email").HasMaxLength(256);
            builder.Property(x => x.CellPhoneNumber).HasColumnName("CellPhoneNumber");
            builder.Property(x => x.Gender).HasColumnName("Gender");
            builder.Property(x => x.Address).HasColumnName("Address");
            builder.Property(x => x.FirstName).HasColumnName("FirstName");
            builder.Property(x => x.LastName).HasColumnName("LastName");
            builder.HasOne(e => e.User).WithOne(o => o.UserRef).HasForeignKey<UserReference>(e => e.Id);
        }

    } 

    
}
