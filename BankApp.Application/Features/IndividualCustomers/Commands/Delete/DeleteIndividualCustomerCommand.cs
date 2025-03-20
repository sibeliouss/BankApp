using MediatR;

namespace BankApp.Application.Features.IndividualCustomers.Commands.Delete;

public class DeleteIndividualCustomerCommand : IRequest<bool>
{
    public Guid Id { get; set; }
} 