using AutoMapper;
using BankApp.Application.Features.CorporateCustomers.Commands.Create;
using BankApp.Application.Features.CorporateCustomers.Commands.Update;
using BankApp.Application.Features.CorporateCustomers.Dtos.Requests;
using BankApp.Application.Features.CorporateCustomers.Dtos.Responses;
using BankApp.Domain.Entities;

namespace BankApp.Application.Features.CorporateCustomers.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CorporateCustomer, CorporateCustomerResponse>();
        CreateMap<CreateCorporateCustomerCommand, CorporateCustomer>();
        CreateMap<UpdateCorporateCustomerCommand, CorporateCustomer>();
        CreateMap<CreateCorporateCustomerRequest, CreateCorporateCustomerCommand>();
    }
} 