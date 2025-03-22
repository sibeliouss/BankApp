using BankApp.Application.Features.IndividualCustomers.Dtos.Responses;
using BankApp.Core.CrossCuttingConcerns.Exceptions.Types;
using BankApp.Core.Repositories;
using BankApp.Domain.Entities;
using MediatR;

namespace BankApp.Application.Features.IndividualCustomers.Queries.GetById;

public class GetIndividualCustomerByIdQueryHandler : IRequestHandler<GetIndividualCustomerByIdQuery, IndividualCustomerResponse>
{
    private readonly IAsyncRepository<IndividualCustomer, Guid> _individualCustomerRepository;

    public GetIndividualCustomerByIdQueryHandler(IAsyncRepository<IndividualCustomer, Guid> individualCustomerRepository)
    {
        _individualCustomerRepository = individualCustomerRepository;
    }

    public async Task<IndividualCustomerResponse> Handle(GetIndividualCustomerByIdQuery request, CancellationToken cancellationToken)
    {
        IndividualCustomer? individualCustomer = await _individualCustomerRepository.GetAsync(
            predicate: ic => ic.Id == request.Id,
            cancellationToken: cancellationToken
        );

        if (individualCustomer is null)
            throw new NotFoundException("Individual customer not found.");

        IndividualCustomerResponse response = new()
        {
            Id = individualCustomer.Id,
            FirstName = individualCustomer.FirstName,
            LastName = individualCustomer.LastName,
            NationalId = individualCustomer.NationalId,
            DateOfBirth = individualCustomer.DateOfBirth,
            Email = individualCustomer.Email,
            PhoneNumber = individualCustomer.PhoneNumber,
            Address = individualCustomer.Address,
            TaxNumber = individualCustomer.TaxNumber,
            TaxOffice = individualCustomer.TaxOffice,
            MotherName = individualCustomer.MotherName,
            FatherName = individualCustomer.FatherName,
            Occupation = individualCustomer.Occupation,
            MonthlyIncome = individualCustomer.MonthlyIncome,
            MaritalStatus = individualCustomer.MaritalStatus,
            EducationLevel = individualCustomer.EducationLevel,
            CreatedDate = individualCustomer.CreatedDate,
            UpdatedDate = individualCustomer.UpdatedDate
        };

        return response;
    }
} 