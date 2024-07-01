using System.Net;
using System.Text.Json;
using Domain.Exceptions;
using Infrastructure.Persistance.Accounts.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Api.ExceptionFilter;

public class ExceptionFilter : IExceptionFilter
{
    private readonly ILogger<ExceptionFilter> _logger;

    public ExceptionFilter(ILogger<ExceptionFilter> logger)
    {
        _logger = logger;
    }
    
    public void OnException(ExceptionContext context)
    {
        var statusCode = HttpStatusCode.InternalServerError;
        var result = string.Empty;

        switch (context.Exception)
        {
            case BadRequestException badRequestException:
                statusCode = HttpStatusCode.BadRequest;
                result = JsonSerializer.Serialize(new
                {
                    error = badRequestException.ErrorMessage
                });
                break;
            
            case CreateUserException createUserException:
                statusCode = HttpStatusCode.BadRequest;
                result = JsonSerializer.Serialize(new
                {
                    error = createUserException.Errors
                });
                break;
            
            case NotFoundException notFoundException:
                statusCode = HttpStatusCode.NotFound;
                result = JsonSerializer.Serialize(new
                {
                    error = notFoundException.ErrorMessage
                });
                break;
            
            default:
                _logger.LogError(context.Exception, "Not supported error");
                result = JsonSerializer.Serialize(new { error = "Somethink went wrong!" });
                break;
        }
        
        context.HttpContext.Response.ContentType = "application/json";
        context.HttpContext.Response.StatusCode = (int)statusCode;

        context.Result = new ContentResult
        {
            Content = result,
            ContentType = "application/json",
            StatusCode = (int)statusCode
        };

        context.ExceptionHandled = true;
    }
}