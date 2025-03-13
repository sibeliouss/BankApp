using BankApp.Core.Repositories;

namespace BankApp.Domain.Entities;

public class Customer : Entity<Guid>
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string Address { get; set; } = null!;
    public bool IsActive { get; set; }
} 