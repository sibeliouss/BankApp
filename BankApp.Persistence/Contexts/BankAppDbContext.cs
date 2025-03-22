using BankApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BankApp.Persistence.Contexts;

public class BankAppDbContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<IndividualCustomer> IndividualCustomers { get; set; }
    public DbSet<CorporateCustomer> CorporateCustomers { get; set; }

    public BankAppDbContext(DbContextOptions<BankAppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BankAppDbContext).Assembly);
    }
} 