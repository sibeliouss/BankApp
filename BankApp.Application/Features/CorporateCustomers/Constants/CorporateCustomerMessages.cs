namespace BankApp.Application.Features.CorporateCustomers.Constants;

public static class CorporateCustomerMessages
{
    public const string CustomerNotFound = "Corporate customer not found";
    public const string CustomerAlreadyExists = "Corporate customer with this trade registry number already exists";
    public const string CompanyNameRequired = "Company name is required";
    public const string TradeRegistryNumberRequired = "Trade registry number is required";
    public const string MersisNumberRequired = "Mersis number is required";
    public const string InvalidMersisNumber = "Invalid Mersis number format";
    public const string CompanyTypeRequired = "Company type is required";
    public const string TaxNumberRequired = "Tax number is required";
    public const string TaxOfficeRequired = "Tax office is required";
    public const string InvalidEstablishmentDate = "Invalid establishment date";
    public const string EstablishmentDateCannotBeInFuture = "Establishment date cannot be in the future";
    public const string InvalidAnnualTurnover = "Annual turnover must be greater than zero";
    public const string InvalidEmployeeCount = "Employee count must be greater than zero";
    public const string DuplicateMersisNumber = "Another company with this Mersis number already exists";
    public const string DuplicateTaxNumber = "Another company with this tax number already exists";
} 