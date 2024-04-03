using Domain.Entities.LinkedEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class OrderProductShelfConfiguration : IEntityTypeConfiguration<OrderProductShelf>
{
    public void Configure(EntityTypeBuilder<OrderProductShelf> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasOne(x => x.ProductShelf)
            .WithMany(x => x.OrderProductShelves)
            .HasForeignKey(x => x.ProductId);
    }
}