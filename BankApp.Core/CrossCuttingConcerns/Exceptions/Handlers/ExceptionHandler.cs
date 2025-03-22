using BankApp.Core.CrossCuttingConcerns.Exceptions.Types;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankApp.Core.CrossCuttingConcerns.Exceptions.Handlers;

public abstract class ExceptionHandler
{
    public Task HandleExceptionAsync(Exception exception)
    {
        if (exception is BusinessException businessException)
            return HandleException(businessException);

        return HandleException(exception);
    }

    protected abstract Task HandleException(BusinessException businessException);
    protected abstract Task HandleException(Exception exception);
} 