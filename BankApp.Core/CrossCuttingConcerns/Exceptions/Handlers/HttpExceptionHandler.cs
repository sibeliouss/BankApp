using BankApp.Core.CrossCuttingConcerns.Exceptions.HttpProblemDetails;
using BankApp.Core.CrossCuttingConcerns.Exceptions.Types;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace BankApp.Core.CrossCuttingConcerns.Exceptions.Handlers;

public class HttpExceptionHandler : ExceptionHandler
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public HttpExceptionHandler(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    protected override async Task HandleException(BusinessException businessException)
    {
        var problemDetails = new BusinessProblemDetails(businessException.Message);
        var response = _httpContextAccessor.HttpContext.Response;
        response.StatusCode = problemDetails.Status ?? StatusCodes.Status400BadRequest;
        await response.WriteAsync(JsonSerializer.Serialize(problemDetails));
    }

    protected override async Task HandleException(Exception exception)
    {
        var problemDetails = new ProblemDetails
        {
            Title = "Internal Server Error",
            Detail = exception.Message,
            Status = StatusCodes.Status500InternalServerError,
            Type = "https://example.com/probs/internal"
        };

        var response = _httpContextAccessor.HttpContext.Response;
        response.StatusCode = problemDetails.Status ?? StatusCodes.Status500InternalServerError;
        await response.WriteAsync(JsonSerializer.Serialize(problemDetails));
    }
} 