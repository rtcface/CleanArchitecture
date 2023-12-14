

using CleanArchitecture.Application.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Api.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);

            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Ocurrio una exception: {Message}", exception.Message);

                var exceptionDetails = GetExeptionDetails(exception);
                var problemDetails = new ProblemDetails
                {
                    Status = exceptionDetails.Status,
                    Type = exceptionDetails.Type,
                    Title = exceptionDetails.Title,
                    Detail = exceptionDetails.Detail
                };
            }
        }

        private static ExceptionDetails GetExeptionDetails(Exception exception)
        {
            return exception switch
            {
                ValidationException validationExcetion => new ExceptionDetails(
                     StatusCodes.Status400BadRequest,
                     "ValidationFailure",
                     "Validacion de Error",
                     "Han ocurrido uno o mas errores de validacion",
                     validationExcetion.Errors
                ),
                _ => new ExceptionDetails(
                 StatusCodes.Status500InternalServerError,
                 "InternalServerError",
                 "Error de Servidor",
                 "Ocurrio un error interno en el servidor",
                 null
                )
            };
        }
    }

    internal record ExceptionDetails(
        int Status,
        string Type,
        string Title,
        string Detail,
        IEnumerable<object>? Errors
    );

}