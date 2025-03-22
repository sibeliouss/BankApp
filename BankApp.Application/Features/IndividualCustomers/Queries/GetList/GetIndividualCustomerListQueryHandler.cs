using BankApp.Application.Features.IndividualCustomers.Dtos.Responses;
using BankApp.Core.Repositories;
using BankApp.Domain.Entities;
using MediatR;

namespace BankApp.Application.Features.IndividualCustomers.Queries.GetList;

public class GetIndividualCustomerListQueryHandler : IRequestHandler<GetIndividualCustomerListQuery, List<IndividualCustomerResponse>>
{
    private readonly IAsyncRepository<IndividualCustomer, Guid> _individualCustomerRepository;

    public GetIndividualCustomerListQueryHandler(IAsyncRepository<IndividualCustomer, Guid> individualCustomerRepository)
    {
        _individualCustomerRepository = individualCustomerRepository;
    }

    public async Task<List<IndividualCustomerResponse>> Handle(GetIndividualCustomerListQuery request, CancellationToken cancellationToken)
    {
        var paginatedList = await _individualCustomerRepository.GetListAsync(cancellationToken: cancellationToken);

        List<IndividualCustomerResponse> response = paginatedList.Items.Select(ic => new IndividualCustomerResponse
        {
            Id = ic.Id,
            FirstName = ic.FirstName,
            LastName = ic.LastName,
            NationalId = ic.NationalId,
            DateOfBirth = ic.DateOfBirth,
            Email = ic.Email,
            PhoneNumber = ic.PhoneNumber,
            Address = ic.Address,
            TaxNumber = ic.TaxNumber,
            TaxOffice = ic.TaxOffice,
            MotherName = ic.MotherName,
            FatherName = ic.FatherName,
            Occupation = ic.Occupation,
            MonthlyIncome = ic.MonthlyIncome,
            MaritalStatus = ic.MaritalStatus,
            EducationLevel = ic.EducationLevel,
            CreatedDate = ic.CreatedDate,
            UpdatedDate = ic.UpdatedDate
        }).ToList();

        return response;
    }
} 