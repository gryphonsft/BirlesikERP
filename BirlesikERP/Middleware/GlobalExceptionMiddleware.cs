using BirlesikERP.Application.Exceptions;
using BirlesikERP.Responses;
using System.Net;

namespace BirlesikERP.Middleware
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public GlobalExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            HttpStatusCode statusCode;
            string message;

            switch (exception)
            {
                case ValidationException:
                    statusCode = HttpStatusCode.BadRequest;
                    message = exception.Message;
                    break;

                case NotFoundException:
                    statusCode = HttpStatusCode.NotFound;
                    message = exception.Message;
                    break;

                case ConflictException:
                    statusCode = HttpStatusCode.Conflict;
                    message = exception.Message;
                    break;

                case UnauthorizedException:
                    statusCode = HttpStatusCode.Unauthorized;
                    message = exception.Message;
                    break;

                case ForbiddenException:
                    statusCode = HttpStatusCode.Forbidden;
                    message = exception.Message;
                    break;

                case BusinessException:
                    statusCode = HttpStatusCode.BadRequest;
                    message = exception.Message;
                    break;

                default:
                    statusCode = HttpStatusCode.InternalServerError;
                    message = "Beklenmeyen bir hata oluştu.";
                    break;
            }

            context.Response.StatusCode = (int)statusCode;

            var response = new ApiResponse
            {
                Success = false,
                Message = message
            };

            await context.Response.WriteAsJsonAsync(response);
        }
    }
}
