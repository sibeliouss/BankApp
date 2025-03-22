using BankApp.Core.CrossCuttingConcerns.Exceptions.Handlers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace BankApp.Core.CrossCuttingConcerns.Exceptions.Middlewares;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly ExceptionHandler _exceptionHandler;

    public ExceptionMiddleware(
        RequestDelegate next,
        IHttpContextAccessor httpContextAccessor,
        ExceptionHandler exceptionHandler)
    {
        _next = next;
        _httpContextAccessor = httpContextAccessor;
        _exceptionHandler = exceptionHandler;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception exception)
        {
            await HandleExceptionAsync(exception);
        }
    }

    private Task HandleExceptionAsync(Exception exception)
    {
        _httpContextAccessor.HttpContext.Response.ContentType = "application/json";
        return _exceptionHandler.HandleExceptionAsync(exception);
    }
}

// Extension method for middleware registration
public static class ExceptionMiddlewareExtensions
{
    public static IApplicationBuilder UseCustomExceptionMiddleware(this IApplicationBuilder app)
    {
        return app.UseMiddleware<ExceptionMiddleware>();
    }
} 