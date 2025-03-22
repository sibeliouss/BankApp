using BankApp.Application.Features.IndividualCustomers.Dtos.Responses;
using MediatR;

namespace BankApp.Application.Features.IndividualCustomers.Queries.GetList;

public class GetIndividualCustomerListQuery : IRequest<List<IndividualCustomerResponse>>
{
} 