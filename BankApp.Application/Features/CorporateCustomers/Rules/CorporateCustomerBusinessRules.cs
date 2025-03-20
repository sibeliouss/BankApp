using BankApp.Application.Features.CorporateCustomers.Constants;
using BankApp.Core.Repositories;
using BankApp.Domain.Entities;

namespace BankApp.Application.Features.CorporateCustomers.Rules;

public class CorporateCustomerBusinessRules
{
    private readonly IAsyncRepository<CorporateCustomer, Guid> _corporateCustomerRepository;

    public CorporateCustomerBusinessRules(IAsyncRepository<CorporateCustomer, Guid> corporateCustomerRepository)
    {
        _corporateCustomerRepository = corporateCustomerRepository;
    }

    public async Task TradeRegistryNumberCannotBeDuplicatedWhenInserted(string tradeRegistryNumber)
    {
        bool exists = await _corporateCustomerRepository.AnyAsync(c => c.TradeRegistryNumber == tradeRegistryNumber);
        if (exists)
            throw new Exception(CorporateCustomerMessages.CustomerAlreadyExists);
    }

    public async Task TradeRegistryNumberCannotBeDuplicatedWhenUpdated(Guid id, string tradeRegistryNumber)
    {
        bool exists = await _corporateCustomerRepository.AnyAsync(c => c.Id != id && c.TradeRegistryNumber == tradeRegistryNumber);
        if (exists)
            throw new Exception(CorporateCustomerMessages.CustomerAlreadyExists);
    }

    public async Task MersisNumberCannotBeDuplicatedWhenInserted(string mersisNumber)
    {
        bool exists = await _corporateCustomerRepository.AnyAsync(c => c.MersisNumber == mersisNumber);
        if (exists)
            throw new Exception(CorporateCustomerMessages.DuplicateMersisNumber);
    }

    public async Task MersisNumberCannotBeDuplicatedWhenUpdated(Guid id, string mersisNumber)
    {
        bool exists = await _corporateCustomerRepository.AnyAsync(c => c.Id != id && c.MersisNumber == mersisNumber);
        if (exists)
            throw new Exception(CorporateCustomerMessages.DuplicateMersisNumber);
    }

    public async Task TaxNumberCannotBeDuplicatedWhenInserted(string taxNumber)
    {
        bool exists = await _corporateCustomerRepository.AnyAsync(c => c.TaxNumber == taxNumber);
        if (exists)
            throw new Exception(CorporateCustomerMessages.DuplicateTaxNumber);
    }

    public async Task TaxNumberCannotBeDuplicatedWhenUpdated(Guid id, string taxNumber)
    {
        bool exists = await _corporateCustomerRepository.AnyAsync(c => c.Id != id && c.TaxNumber == taxNumber);
        if (exists)
            throw new Exception(CorporateCustomerMessages.DuplicateTaxNumber);
    }

    public Task EstablishmentDateCannotBeInFuture(DateTime establishmentDate)
    {
        if (establishmentDate > DateTime.UtcNow)
            throw new Exception(CorporateCustomerMessages.EstablishmentDateCannotBeInFuture);

        return Task.CompletedTask;
    }
} 