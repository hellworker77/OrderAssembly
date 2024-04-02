using Domain.Entities;
using Domain.Entities.LinkedEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasMany(x => x.ProductShelves)
            .WithOne(x => x.Order)
            .HasForeignKey(x=>x.OrderId);
    }
}