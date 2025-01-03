using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DAL.Entities;
namespace DAL.Configuration
{
    public class UserCongiguration : IEntityTypeConfiguration<User>
    {
        public class UserConfiguration : IEntityTypeConfiguration<User>
        {
            public void Configure(EntityTypeBuilder<User> builder)
            {
                builder.ToTable("Users");
                // Primary key
                builder.HasKey(u => u.Id);
                // Properties
                builder.Property(u => u.Name)
                       .IsRequired()
                       .HasMaxLength(100);
                builder.Property(u => u.Email)
                       .IsRequired()
                       .HasMaxLength(150);
                // Index (e.g., for unique email)
                builder.HasIndex(u => u.Email).IsUnique();
                // Relationships (One-to-Many: User -> Orders)
                builder.HasMany(u => u.Orders)
                       .WithOne(o => o.User)
                       .HasForeignKey(o => o.UserId)
                       .OnDelete(DeleteBehavior.Cascade);
            }
        }
    }
}

