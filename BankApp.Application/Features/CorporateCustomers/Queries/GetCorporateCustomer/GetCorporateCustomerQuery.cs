using BankApp.Application.Features.CorporateCustomers.Dtos.Responses;
using MediatR;

namespace BankApp.Application.Features.CorporateCustomers.Queries.GetCorporateCustomer;

public class GetCorporateCustomerQuery : IRequest<CorporateCustomerResponse>
{
    public Guid Id { get; set; }
} 