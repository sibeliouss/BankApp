namespace BankApp.Application.Features.IndividualCustomers.Dtos.Requests;

public class CreateIndividualCustomerRequest
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string NationalId { get; set; } = null!;
    public DateTime DateOfBirth { get; set; }
    public string Email { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string TaxNumber { get; set; } = null!;
    public string TaxOffice { get; set; } = null!;
    public string? MotherName { get; set; }
    public string? FatherName { get; set; }
    public string? Occupation { get; set; }
    public decimal? MonthlyIncome { get; set; }
    public string? MaritalStatus { get; set; }
    public string? EducationLevel { get; set; }
} 