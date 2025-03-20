using BankApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankApp.Persistence.EntityConfigurations;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("Customers");
        
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id).HasDefaultValueSql("NEWID()");
        
        builder.Property(c => c.Email).HasMaxLength(100).IsRequired();
        builder.HasIndex(c => c.Email).IsUnique();
        
        builder.Property(c => c.PhoneNumber).HasMaxLength(20).IsRequired();
        builder.Property(c => c.Address).HasMaxLength(500).IsRequired();
        builder.Property(c => c.TaxNumber).HasMaxLength(50).IsRequired();
        builder.Property(c => c.TaxOffice).HasMaxLength(100).IsRequired();
        
        builder.Property(c => c.PasswordHash).HasMaxLength(500);
        builder.Property(c => c.Salt).HasMaxLength(500);
        
        builder.Property(c => c.CreatedDate).IsRequired();
        builder.Property(c => c.UpdatedDate);
        builder.Property(c => c.DeletedDate);
        
        builder.HasQueryFilter(c => c.DeletedDate == null);
    }
} 