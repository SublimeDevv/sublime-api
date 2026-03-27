using Base.Application.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Base.API.Middleware
{
    public class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger) : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(
            HttpContext httpContext,
            Exception exception,
            CancellationToken cancellationToken)
        {
            var (statusCode, title, errors) = exception switch
            {
                ValidationExceptionFluent ve => (
                    StatusCodes.Status400BadRequest,
                    "Validation failed",
                    ve.Errors),

                BusinessRuleException => (
                    StatusCodes.Status400BadRequest,
                    "Business rule violation",
                    [exception.Message]),

                NotFoundException => (
                    StatusCodes.Status404NotFound,
                    "Resource not found",
                    [exception.Message]),

                KeyNotFoundException => (
                    StatusCodes.Status404NotFound,
                    "Resource not found",
                    [exception.Message]),

                UnauthorizedAccessException => (
                    StatusCodes.Status401Unauthorized,
                    "Unauthorized Access",
                    [exception.Message]),
                
                InvalidOperationException => (
                    StatusCodes.Status409Conflict,
                    "Operation not allowed",
                    [exception.Message]),

                _ => (
                    StatusCodes.Status500InternalServerError,
                    "An unexpected error occurred",
                    ["An internal server error has occurred."])
            };

            if (statusCode == StatusCodes.Status500InternalServerError)
                logger.LogError(exception, "Unhandled exception: {Message}", exception.Message);

            var problemDetails = new ProblemDetails
            {
                Status = statusCode,
                Title = title,
                Extensions = { ["errors"] = errors }
            };

            httpContext.Response.StatusCode = statusCode;
            await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

            return true;
        }
    }
}
