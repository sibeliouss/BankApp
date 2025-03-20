using MediatR;

namespace BankApp.Application.Features.CorporateCustomers.Commands.Delete;

public class DeleteCorporateCustomerCommand : IRequest<bool>
{
    public Guid Id { get; set; }
} 