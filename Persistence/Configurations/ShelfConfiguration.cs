using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class ShelfConfiguration : IEntityTypeConfiguration<Shelf>
{
    public void Configure(EntityTypeBuilder<Shelf> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasMany(x => x.ProductShelves)
            .WithOne(x => x.Shelf)
            .HasForeignKey(x => x.ShelfId);
    }
}