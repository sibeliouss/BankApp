using BankApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankApp.Persistence.EntityConfigurations;

public class IndividualCustomerConfiguration : IEntityTypeConfiguration<IndividualCustomer>
{
    public void Configure(EntityTypeBuilder<IndividualCustomer> builder)
    {
        builder.ToTable("IndividualCustomers");

        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id).HasDefaultValueSql("NEWID()");

        builder.Property(c => c.FirstName).HasMaxLength(50).IsRequired();
        builder.Property(c => c.LastName).HasMaxLength(50).IsRequired();
        builder.Property(c => c.NationalId).HasMaxLength(11).IsRequired();
        builder.HasIndex(c => c.NationalId).IsUnique();

        builder.Property(c => c.DateOfBirth).IsRequired();
        builder.Property(c => c.MotherName).HasMaxLength(50);
        builder.Property(c => c.FatherName).HasMaxLength(50);
        builder.Property(c => c.Occupation).HasMaxLength(100);
        builder.Property(c => c.MonthlyIncome).HasPrecision(18, 2);
        builder.Property(c => c.MaritalStatus).HasMaxLength(20);
        builder.Property(c => c.EducationLevel).HasMaxLength(50);

        builder.HasOne<Customer>().WithOne()
            .HasForeignKey<IndividualCustomer>(c => c.Id)
            .OnDelete(DeleteBehavior.Cascade);
    }
} 