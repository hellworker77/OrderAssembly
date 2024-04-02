using Domain.Entities.LinkedEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class OrderProductShelfConfiguration : IEntityTypeConfiguration<OrderProductShelf>
{
    public void Configure(EntityTypeBuilder<OrderProductShelf> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasOne(x => x.Product)
            .WithOne(x => x.OrderProductShelf)
            .HasForeignKey<OrderProductShelf>(x => x.ProductId);
    }
}