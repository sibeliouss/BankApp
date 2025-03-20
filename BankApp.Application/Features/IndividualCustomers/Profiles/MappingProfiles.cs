using AutoMapper;
using BankApp.Application.Features.IndividualCustomers.Commands.Create;
using BankApp.Application.Features.IndividualCustomers.Commands.Update;
using BankApp.Application.Features.IndividualCustomers.Dtos.Requests;
using BankApp.Application.Features.IndividualCustomers.Dtos.Responses;
using BankApp.Domain.Entities;

namespace BankApp.Application.Features.IndividualCustomers.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<IndividualCustomer, IndividualCustomerResponse>();
        CreateMap<CreateIndividualCustomerCommand, IndividualCustomer>();
        CreateMap<UpdateIndividualCustomerCommand, IndividualCustomer>();
        CreateMap<CreateIndividualCustomerRequest, CreateIndividualCustomerCommand>();
    }
} 