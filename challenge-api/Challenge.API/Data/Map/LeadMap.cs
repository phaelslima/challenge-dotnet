using Challenge.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Challenge.API.Data.Map
{
    public class LeadMap : IEntityTypeConfiguration<LeadModel>
    {
        public void Configure(EntityTypeBuilder<LeadModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(150);
            builder.Property(x => x.Phone).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.Suburb).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Category).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(500);
            builder.Property(x => x.Price).IsRequired();
            builder.Property(x => x.TotalPrice).IsRequired();
            builder.Property(x => x.CreatedAt).IsRequired();
        }
    }
}
