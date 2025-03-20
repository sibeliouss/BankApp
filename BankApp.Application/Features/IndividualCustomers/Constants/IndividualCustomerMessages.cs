namespace BankApp.Application.Features.IndividualCustomers.Constants;

public static class IndividualCustomerMessages
{
    public const string CustomerNotFound = "Individual customer not found";
    public const string CustomerAlreadyExists = "Individual customer with this national ID already exists";
    public const string NationalIdRequired = "National ID is required";
    public const string InvalidNationalId = "Invalid national ID format";
    public const string FirstNameRequired = "First name is required";
    public const string LastNameRequired = "Last name is required";
    public const string InvalidDateOfBirth = "Invalid date of birth";
    public const string CustomerTooYoung = "Customer must be at least 18 years old";
} 