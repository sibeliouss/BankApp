using AutoMapper;
using BankApp.Application.Features.IndividualCustomers.Dtos.Responses;
using BankApp.Application.Features.IndividualCustomers.Rules;
using BankApp.Core.Repositories;
using BankApp.Domain.Entities;
using MediatR;

namespace BankApp.Application.Features.IndividualCustomers.Commands.Create;

public class CreateIndividualCustomerCommandHandler : IRequestHandler<CreateIndividualCustomerCommand, IndividualCustomerResponse>
{
    private readonly IAsyncRepository<IndividualCustomer, Guid> _individualCustomerRepository;
    private readonly IMapper _mapper;
    private readonly IndividualCustomerBusinessRules _businessRules;

    public CreateIndividualCustomerCommandHandler(
        IAsyncRepository<IndividualCustomer, Guid> individualCustomerRepository,
        IMapper mapper,
        IndividualCustomerBusinessRules businessRules)
    {
        _individualCustomerRepository = individualCustomerRepository;
        _mapper = mapper;
        _businessRules = businessRules;
    }

    public async Task<IndividualCustomerResponse> Handle(CreateIndividualCustomerCommand request, CancellationToken cancellationToken)
    {
        await _businessRules.NationalIdCannotBeDuplicatedWhenInserted(request.NationalId);
        await _businessRules.CustomerMustBeAtLeast18YearsOld(request.DateOfBirth);

        IndividualCustomer individualCustomer = _mapper.Map<IndividualCustomer>(request);
        IndividualCustomer createdCustomer = await _individualCustomerRepository.AddAsync(individualCustomer, cancellationToken);
        IndividualCustomerResponse customerResponse = _mapper.Map<IndividualCustomerResponse>(createdCustomer);
        
        return customerResponse;
    }
} 