using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace BankApp.Core.CrossCuttingConcerns.Exceptions.Handlers;

public class HttpExceptionHandler : IExceptionHandler
{
    public async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = StatusCodes.Status500InternalServerError;

        var response = new
        {
            error = new
            {
                message = exception.Message,
                statusCode = context.Response.StatusCode
            }
        };

        await context.Response.WriteAsync(JsonSerializer.Serialize(response));
    }
} 