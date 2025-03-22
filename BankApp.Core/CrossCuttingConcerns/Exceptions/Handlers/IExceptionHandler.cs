using Microsoft.AspNetCore.Http;

namespace BankApp.Core.CrossCuttingConcerns.Exceptions.Handlers;

public interface IExceptionHandler
{
    Task HandleExceptionAsync(HttpContext context, Exception exception);
} 