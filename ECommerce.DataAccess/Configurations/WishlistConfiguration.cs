using System;
using System.Collections.Generic;
using System.Text;

using ECommerce.Entity.Wishlist;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.DataAccess.Configurations
{
    public class WishlistConfiguration : IEntityTypeConfiguration<Wishlist>
    {
        public void Configure(EntityTypeBuilder<Wishlist> builder)
        {
            builder.HasKey(x => x.WishlistId);

            builder.Property(x => x.WishlistId)
                .ValueGeneratedOnAdd();

            builder.HasOne(x => x.User)
                .WithOne()
                .HasForeignKey<Wishlist>(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(x => x.UserId)
                .IsUnique();
        }
    }
}
