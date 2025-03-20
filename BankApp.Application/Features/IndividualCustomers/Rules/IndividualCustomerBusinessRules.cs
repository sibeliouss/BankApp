using BankApp.Application.Features.IndividualCustomers.Constants;
using BankApp.Core.Repositories;
using BankApp.Domain.Entities;

namespace BankApp.Application.Features.IndividualCustomers.Rules;

public class IndividualCustomerBusinessRules
{
    private readonly IAsyncRepository<IndividualCustomer, Guid> _individualCustomerRepository;

    public IndividualCustomerBusinessRules(IAsyncRepository<IndividualCustomer, Guid> individualCustomerRepository)
    {
        _individualCustomerRepository = individualCustomerRepository;
    }

    public async Task NationalIdCannotBeDuplicatedWhenInserted(string nationalId)
    {
        bool exists = await _individualCustomerRepository.AnyAsync(c => c.NationalId == nationalId);
        if (exists)
            throw new Exception(IndividualCustomerMessages.CustomerAlreadyExists);
    }

    public async Task NationalIdCannotBeDuplicatedWhenUpdated(Guid id, string nationalId)
    {
        bool exists = await _individualCustomerRepository.AnyAsync(c => c.Id != id && c.NationalId == nationalId);
        if (exists)
            throw new Exception(IndividualCustomerMessages.CustomerAlreadyExists);
    }

    public Task CustomerMustBeAtLeast18YearsOld(DateTime dateOfBirth)
    {
        var age = DateTime.UtcNow.Year - dateOfBirth.Year;
        if (DateTime.UtcNow.DayOfYear < dateOfBirth.DayOfYear)
            age--;

        if (age < 18)
            throw new Exception(IndividualCustomerMessages.CustomerTooYoung);

        return Task.CompletedTask;
    }
} 