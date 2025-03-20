using BankApp.Application.Features.IndividualCustomers.Constants;
using BankApp.Core.Repositories;
using BankApp.Domain.Entities;
using MediatR;

namespace BankApp.Application.Features.IndividualCustomers.Commands.Delete;

public class DeleteIndividualCustomerCommandHandler : IRequestHandler<DeleteIndividualCustomerCommand, bool>
{
    private readonly IAsyncRepository<IndividualCustomer, Guid> _individualCustomerRepository;

    public DeleteIndividualCustomerCommandHandler(IAsyncRepository<IndividualCustomer, Guid> individualCustomerRepository)
    {
        _individualCustomerRepository = individualCustomerRepository;
    }

    public async Task<bool> Handle(DeleteIndividualCustomerCommand request, CancellationToken cancellationToken)
    {
        IndividualCustomer? customer = await _individualCustomerRepository.GetAsync(
            predicate: c => c.Id == request.Id,
            cancellationToken: cancellationToken
        );

        if (customer == null)
            throw new Exception(IndividualCustomerMessages.CustomerNotFound);

        await _individualCustomerRepository.DeleteAsync(customer, true, cancellationToken);
        return true;
    }
} 