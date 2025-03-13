namespace BankApp.Domain.Entities;

public class IndividualCustomer : Customer
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string NationalId { get; set; } = null!;
    public DateTime DateOfBirth { get; set; }
    public string? MotherName { get; set; }
    public string? FatherName { get; set; }
    public string? Occupation { get; set; }
    public decimal? MonthlyIncome { get; set; }
    public string? MaritalStatus { get; set; }
    public string? EducationLevel { get; set; }
} 