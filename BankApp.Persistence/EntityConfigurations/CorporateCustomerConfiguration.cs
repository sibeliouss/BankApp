using BankApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankApp.Persistence.EntityConfigurations;

public class CorporateCustomerConfiguration : IEntityTypeConfiguration<CorporateCustomer>
{
    public void Configure(EntityTypeBuilder<CorporateCustomer> builder)
    {
        builder.ToTable("CorporateCustomers");

        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id).HasDefaultValueSql("NEWID()");

        builder.Property(c => c.CompanyName).HasMaxLength(200).IsRequired();
        builder.Property(c => c.TradeRegistryNumber).HasMaxLength(50).IsRequired();
        builder.HasIndex(c => c.TradeRegistryNumber).IsUnique();
        
        builder.Property(c => c.MersisNumber).HasMaxLength(50).IsRequired();
        builder.HasIndex(c => c.MersisNumber).IsUnique();
        
        builder.Property(c => c.CompanyType).HasMaxLength(50).IsRequired();
        builder.Property(c => c.Website).HasMaxLength(200);
        builder.Property(c => c.AnnualTurnover).HasPrecision(18, 2);
        builder.Property(c => c.Industry).HasMaxLength(100);
        builder.Property(c => c.CompanySize).HasMaxLength(50);
        builder.Property(c => c.EstablishmentDate).IsRequired();
        builder.Property(c => c.ChamberOfCommerce).HasMaxLength(100);

        builder.HasOne<Customer>().WithOne()
            .HasForeignKey<CorporateCustomer>(c => c.Id)
            .OnDelete(DeleteBehavior.Cascade);
    }
} 