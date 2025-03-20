using AutoMapper;
using BankApp.Application.Features.IndividualCustomers.Constants;
using BankApp.Application.Features.IndividualCustomers.Dtos.Responses;
using BankApp.Application.Features.IndividualCustomers.Rules;
using BankApp.Core.Repositories;
using BankApp.Domain.Entities;
using MediatR;

namespace BankApp.Application.Features.IndividualCustomers.Commands.Update;

public class UpdateIndividualCustomerCommandHandler : IRequestHandler<UpdateIndividualCustomerCommand, IndividualCustomerResponse>
{
    private readonly IAsyncRepository<IndividualCustomer, Guid> _individualCustomerRepository;
    private readonly IMapper _mapper;
    private readonly IndividualCustomerBusinessRules _businessRules;

    public UpdateIndividualCustomerCommandHandler(
        IAsyncRepository<IndividualCustomer, Guid> individualCustomerRepository,
        IMapper mapper,
        IndividualCustomerBusinessRules businessRules)
    {
        _individualCustomerRepository = individualCustomerRepository;
        _mapper = mapper;
        _businessRules = businessRules;
    }

    public async Task<IndividualCustomerResponse> Handle(UpdateIndividualCustomerCommand request, CancellationToken cancellationToken)
    {
        IndividualCustomer? customer = await _individualCustomerRepository.GetAsync(
            predicate: c => c.Id == request.Id,
            cancellationToken: cancellationToken
        );

        if (customer == null)
            throw new Exception(IndividualCustomerMessages.CustomerNotFound);

        await _businessRules.NationalIdCannotBeDuplicatedWhenUpdated(request.Id, request.NationalId);
        await _businessRules.CustomerMustBeAtLeast18YearsOld(request.DateOfBirth);

        _mapper.Map(request, customer);
        IndividualCustomer updatedCustomer = await _individualCustomerRepository.UpdateAsync(customer, cancellationToken);
        IndividualCustomerResponse customerResponse = _mapper.Map<IndividualCustomerResponse>(updatedCustomer);
        
        return customerResponse;
    }
} 