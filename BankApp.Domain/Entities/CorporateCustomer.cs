namespace BankApp.Domain.Entities;

public class CorporateCustomer : Customer
{
    public string CompanyName { get; set; } = null!;
    public string TradeRegistryNumber { get; set; } = null!;
    public string MersisNumber { get; set; } = null!;
    public string CompanyType { get; set; } = null!;
    public string? Website { get; set; }
    public decimal? AnnualTurnover { get; set; }
    public int? EmployeeCount { get; set; }
    public string? Industry { get; set; }
    public string? CompanySize { get; set; }
    public DateTime EstablishmentDate { get; set; }
    public string? ChamberOfCommerce { get; set; }
} 