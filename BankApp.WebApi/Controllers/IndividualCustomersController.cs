using BankApp.Application.Features.IndividualCustomers.Commands.Create;
using BankApp.Application.Features.IndividualCustomers.Dtos.Requests;
using BankApp.Application.Features.IndividualCustomers.Dtos.Responses;
using BankApp.Application.Features.IndividualCustomers.Queries.GetById;
using BankApp.Application.Features.IndividualCustomers.Queries.GetList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BankApp.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class IndividualCustomersController : ControllerBase
{
    private readonly IMediator _mediator;

    public IndividualCustomersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult<IndividualCustomerResponse>> Create([FromBody] CreateIndividualCustomerRequest request)
    {
        CreateIndividualCustomerCommand command = new() { 
            FirstName = request.FirstName,
            LastName = request.LastName,
            NationalId = request.NationalId,
            DateOfBirth = request.DateOfBirth,
            Email = request.Email,
            PhoneNumber = request.PhoneNumber,
            Address = request.Address,
            TaxNumber = request.TaxNumber,
            TaxOffice = request.TaxOffice,
            MotherName = request.MotherName,
            FatherName = request.FatherName,
            Occupation = request.Occupation,
            MonthlyIncome = request.MonthlyIncome,
            MaritalStatus = request.MaritalStatus,
            EducationLevel = request.EducationLevel
        };

        IndividualCustomerResponse response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<IndividualCustomerResponse>> GetById([FromRoute] Guid id)
    {
        GetIndividualCustomerByIdQuery query = new() { Id = id };
        IndividualCustomerResponse response = await _mediator.Send(query);
        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<List<IndividualCustomerResponse>>> GetList()
    {
        GetIndividualCustomerListQuery query = new();
        List<IndividualCustomerResponse> response = await _mediator.Send(query);
        return Ok(response);
    }
} 