using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace UPD8.CSharp.Infrastructure.Entities.EF
{
    public class CustomerEntity
    {
        public long Id { get; set; } = 0;
        public string Document { get; set; } = null;
        public string Name { get; set; } = null;
        public DateTime? Birth { get; set; } = null;
        public string Gender { get; set; } = null;
        public string Address { get; set; } = null;
        public string State { get; set; } = null;
        public string City { get; set; } = null;

        [JsonIgnore]
        [NotMapped]
        public string BirthText { get; set; } = null;
    }

    public class CustomerConfig : IEntityTypeConfiguration<CustomerEntity>
    {
        public void Configure(EntityTypeBuilder<CustomerEntity> builder)
        {
            builder.ToTable("CUSTOMER");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("ID_CUSTOMER");
            builder.Property(e => e.Document).HasColumnName("DOCUMENT").IsRequired().HasMaxLength(15);
            builder.Property(e => e.Name).HasColumnName("NAME").IsRequired().HasMaxLength(150);
            builder.Property(e => e.Birth).HasColumnName("BIRTH").IsRequired();
            builder.Property(e => e.Gender).HasColumnName("GENDER").IsRequired().HasMaxLength(5);
            builder.Property(e => e.Address).HasColumnName("ADDRESS").IsRequired().HasMaxLength(250);
            builder.Property(e => e.State).HasColumnName("STATE").IsRequired().HasMaxLength(50);
            builder.Property(e => e.City).HasColumnName("CITY").IsRequired().HasMaxLength(100);
        }
    }
}
