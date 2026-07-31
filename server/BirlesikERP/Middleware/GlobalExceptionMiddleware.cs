using BirlesikERP.Application.Exceptions;
using BirlesikERP.Responses;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace BirlesikERP.Middleware;

public class GlobalExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<GlobalExceptionMiddleware> _logger;
    private readonly IWebHostEnvironment _environment;

    public GlobalExceptionMiddleware(
        RequestDelegate next,
        ILogger<GlobalExceptionMiddleware> logger,
        IWebHostEnvironment environment)
    {
        _next = next;
        _logger = logger;
        _environment = environment;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception exception)
        {
            _logger.LogError(exception, exception.Message);

            await HandleExceptionAsync(context, exception);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";

        var statusCode = exception switch
        {
            ValidationException => HttpStatusCode.BadRequest,
            NotFoundException => HttpStatusCode.NotFound,
            ConflictException => HttpStatusCode.Conflict,
            UnauthorizedException => HttpStatusCode.Unauthorized,
            ForbiddenException => HttpStatusCode.Forbidden,
            BusinessException => HttpStatusCode.BadRequest,
            _ => HttpStatusCode.InternalServerError
        };

        context.Response.StatusCode = (int)statusCode;

        var response = new ApiResponse
        {
            Success = false,
            Message = GetMessage(exception)
        };

        await context.Response.WriteAsJsonAsync(response);
    }

    private string GetMessage(Exception exception)
    {    
        if (exception is ValidationException or
            NotFoundException or
            ConflictException or
            UnauthorizedException or
            ForbiddenException or
            BusinessException)
        {
            return exception.Message;
        }
     
        if (_environment.IsDevelopment())
        {
            return exception.ToString();
        }
       
        return "Beklenmeyen bir hata oluştu.";
    }
}