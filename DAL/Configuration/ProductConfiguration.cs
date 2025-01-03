using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DAL.Entities;
namespace DAL.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            // Table name
            builder.ToTable("Products");
            // Primary key
            builder.HasKey(p => p.Id);
            // Properties
            builder.Property(p => p.Name)
                   .IsRequired()
                   .HasMaxLength(200);
            builder.Property(p => p.Price)
                   .IsRequired()
                   .HasColumnType("decimal(18,2)");
            // Relationships
            builder.HasMany(p => p.OrderDetails)
                   .WithOne(od => od.Product)
                   .HasForeignKey(od => od.ProductId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

