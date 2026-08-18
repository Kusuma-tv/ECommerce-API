using System;
using System.Collections.Generic;
using System.Text;

using ECommerce.Entity.Wishlist;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.DataAccess.Configurations
{
    public class WishlistItemConfiguration : IEntityTypeConfiguration<WishlistItem>
    {
        public void Configure(EntityTypeBuilder<WishlistItem> builder)
        {
            builder.HasKey(x => x.WishlistItemId);

            builder.Property(x => x.WishlistItemId)
                .ValueGeneratedOnAdd();

            builder.HasOne(x => x.Wishlist)
                .WithMany(x => x.WishlistItems)
                .HasForeignKey(x => x.WishlistId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Product)
                .WithMany()
                .HasForeignKey(x => x.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(x => new
            {
                x.WishlistId,
                x.ProductId
            })
            .IsUnique();
        }
    }
}
