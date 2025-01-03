using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DAL.Entities; // Replace with your actual namespace

namespace DAL.Configuration // Replace with your actual namespace
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");
            builder.HasKey(o => o.Id);
            builder.Property(o => o.OrderDate)
                   .IsRequired();
            // Relationships
            builder.HasOne(o => o.User) // Navigation property in Order
                   .WithMany(u => u.Orders) // Inverse navigation in User
                   .HasForeignKey(o => o.UserId) // Foreign key in Order
                   .OnDelete(DeleteBehavior.Cascade); // Cascade delete when User is deleted
            builder.HasMany(o => o.OrderDetails) // Navigation property in Order
                   .WithOne(od => od.Order) // Inverse navigation in OrderDetail
                   .HasForeignKey(od => od.OrderId) // Foreign key in OrderDetail
                   .OnDelete(DeleteBehavior.Cascade); // Cascade delete when Order is deleted
        }
    }
}

