using AutoMapper;
using BankApp.Application.Features.CorporateCustomers.Constants;
using BankApp.Application.Features.CorporateCustomers.Dtos.Responses;
using BankApp.Core.Repositories;
using BankApp.Domain.Entities;
using MediatR;

namespace BankApp.Application.Features.CorporateCustomers.Queries.GetCorporateCustomer;

public class GetCorporateCustomerQueryHandler : IRequestHandler<GetCorporateCustomerQuery, CorporateCustomerResponse>
{
    private readonly IAsyncRepository<CorporateCustomer, Guid> _corporateCustomerRepository;
    private readonly IMapper _mapper;

    public GetCorporateCustomerQueryHandler(
        IAsyncRepository<CorporateCustomer, Guid> corporateCustomerRepository,
        IMapper mapper)
    {
        _corporateCustomerRepository = corporateCustomerRepository;
        _mapper = mapper;
    }

    public async Task<CorporateCustomerResponse> Handle(GetCorporateCustomerQuery request, CancellationToken cancellationToken)
    {
        CorporateCustomer? customer = await _corporateCustomerRepository.GetAsync(
            predicate: c => c.Id == request.Id,
            cancellationToken: cancellationToken
        );

        if (customer == null)
            throw new Exception(CorporateCustomerMessages.CustomerNotFound);

        CorporateCustomerResponse customerResponse = _mapper.Map<CorporateCustomerResponse>(customer);
        return customerResponse;
    }
} 