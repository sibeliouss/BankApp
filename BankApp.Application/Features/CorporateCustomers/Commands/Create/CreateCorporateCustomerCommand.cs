using BankApp.Application.Features.CorporateCustomers.Dtos.Responses;
using MediatR;

namespace BankApp.Application.Features.CorporateCustomers.Commands.Create;

public class CreateCorporateCustomerCommand : IRequest<CorporateCustomerResponse>
{
    public string CompanyName { get; set; } = null!;
    public string TradeRegistryNumber { get; set; } = null!;
    public string MersisNumber { get; set; } = null!;
    public string CompanyType { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string TaxNumber { get; set; } = null!;
    public string TaxOffice { get; set; } = null!;
    public string? Website { get; set; }
    public decimal? AnnualTurnover { get; set; }
    public int? EmployeeCount { get; set; }
    public string? Industry { get; set; }
    public string? CompanySize { get; set; }
    public DateTime EstablishmentDate { get; set; }
    public string? ChamberOfCommerce { get; set; }
} 