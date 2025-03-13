using BankApp.Core.Repositories;

namespace BankApp.Domain.Entities;

public abstract class Customer : Entity<Guid>
{
    public string Email { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string Address { get; set; } = null!;
    public bool IsActive { get; set; }
    public string TaxNumber { get; set; } = null!;
    public string TaxOffice { get; set; } = null!;
    public DateTime? LastLoginDate { get; set; }
    public string? PasswordHash { get; set; }
    public string? Salt { get; set; }
} 