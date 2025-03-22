using BankApp.Application.Features.IndividualCustomers.Dtos.Responses;
using MediatR;

namespace BankApp.Application.Features.IndividualCustomers.Queries.GetById;

public class GetIndividualCustomerByIdQuery : IRequest<IndividualCustomerResponse>
{
    public Guid Id { get; set; }
} 