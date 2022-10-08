using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;

namespace UPD8.CSharp.Infrastructure.Entities.EF
{
    public class CustomerEntity
    {
        public long Id { get; set; }
        public string Document { get; set; }
        public string Name { get; set; }
        public DateTime Birth { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string State { get; set; }
        public string City { get; set; }
    }

    public class CustomerConfig : IEntityTypeConfiguration<CustomerEntity>
    {
        public void Configure(EntityTypeBuilder<CustomerEntity> builder)
        {
            builder.ToTable("CUSTOMER");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("ID_CUSTOMER");
            builder.Property(e => e.Document).HasColumnName("DOCUMENT");
            builder.Property(e => e.Name).HasColumnName("NAME");
            builder.Property(e => e.Birth).HasColumnName("BIRTH");
            builder.Property(e => e.Gender).HasColumnName("GENDER");
            builder.Property(e => e.Address).HasColumnName("ADDRESS");
            builder.Property(e => e.State).HasColumnName("STATE");
            builder.Property(e => e.City).HasColumnName("CITY");

        }
    }
}
