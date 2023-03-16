using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using PTP.Gateway.Business.Exceptions;
using System.Diagnostics;
using PTP.Gateway.Business.Models;
using PTP.Gateway.Business.Extensions;
using FluentValidation;
using PTP.Gateway.Business;

namespace PTP.Gateway.API.Filters
{
    public class HttpResponseExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<HttpResponseExceptionFilter> _logger;

        public HttpResponseExceptionFilter(ILogger<HttpResponseExceptionFilter> logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            if (context?.Exception == null) return;

            if (context?.Exception is GatewayException gEx)
            {
                var err = new List<ErrorResponse>{ new ErrorResponse
                {
                    ErrorCode = ((int)gEx.ErrorCode).ToString(),
                    ErrorSubCode = ((int)gEx.ErrorSubCode).ToString(),
                    Message = gEx.Message,
                    TraceId = Activity.Current?.Id ?? string.Empty,
                    RequestId = context?.HttpContext?.TraceIdentifier ?? string.Empty
                } };

#pragma warning disable CS8602 // Dereference of a possibly null reference.
                context.Result = new ObjectResult(err) { StatusCode = gEx.ErrorSubCode.GetHttpStatusCode() };
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            }
            else if (context?.Exception is ValidationException vEx)
            {
                var errMsgs = vEx.Errors.Select(x => new ErrorResponse
                {
                    ErrorCode = string.Empty,
                    ErrorSubCode= x.ErrorCode,
                    Message = vEx.Message,
                    TraceId = Activity.Current?.Id ?? string.Empty,
                    RequestId = context?.HttpContext?.TraceIdentifier ?? string.Empty
                });

                var httpStatusCode = ((ErrorSubCodes) int.Parse(vEx.Errors.First().ErrorCode)).GetHttpStatusCode();
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                context.Result = new ObjectResult(errMsgs) { StatusCode = httpStatusCode };
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            }
            else
            {
                var errMsg = new List<ErrorResponse> { new ErrorResponse
                {
                    ErrorCode = ((int)ErrorCodes.GenericFailure).ToString(),
                    Message = $"Unhandled exception: {context?.Exception.Message}",
                    TraceId = Activity.Current?.Id ?? string.Empty,
                    RequestId = context?.HttpContext?.TraceIdentifier ?? string.Empty
                } };

#pragma warning disable CS8602 // Dereference of a possibly null reference.
                context.Result = new ObjectResult(errMsg) { StatusCode = (int)StatusCodes.Status500InternalServerError };
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            }

            context.ExceptionHandled = true;
        }


    }
}
