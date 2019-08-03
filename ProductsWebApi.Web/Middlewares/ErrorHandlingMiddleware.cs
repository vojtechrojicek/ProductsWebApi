using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;
using Microsoft.Net.Http.Headers;
using ProductsWebApi.Web.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsWebApi.Web.Middlewares
{
    /// <summary>
    /// Middleware handles erros and sends exception to client.
    /// </summary>
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlingMiddleware> _logger;
        private static readonly HashSet<string> _preservedHeaders = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            HeaderNames.AccessControlAllowCredentials,
            HeaderNames.AccessControlAllowHeaders,
            HeaderNames.AccessControlAllowMethods,
            HeaderNames.AccessControlAllowOrigin,
            HeaderNames.AccessControlExposeHeaders,
            HeaderNames.AccessControlMaxAge,
        };

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="next">Delegate for next middleware.</param>
        /// <param name="logger">Logger.</param>
        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        /// <summary>
        /// Invoke.
        /// </summary>
        /// <param name="context">Current http context.</param>
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (NotFoundException ex)
            {
                SetResponseType(context, ex, StatusCodes.Status404NotFound);
            }
            catch (Exception ex) when (!context.Response.HasStarted && IsSuccessStatusCode(context.Response.StatusCode))
            {
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        private void SetResponseType(HttpContext context, Exception ex, int statusCode)
        {
            if (!context.Response.HasStarted)
            {
                ClearExceptCorsHeaders(context.Response);
                context.Response.StatusCode = statusCode;
            }
            _logger.LogError(ex, ex.Message);
        }

        private static bool IsSuccessStatusCode(int statusCode)
            => (statusCode >= StatusCodes.Status200OK) && (statusCode < StatusCodes.Status300MultipleChoices);

        private static void ClearExceptCorsHeaders(HttpResponse response)
        {
            var headers = new HeaderDictionary();

            headers.Append(HeaderNames.CacheControl, "no-cache, no-store, must-revalidate");
            headers.Append(HeaderNames.Pragma, "no-cache");
            headers.Append(HeaderNames.Expires, "0");

            foreach (KeyValuePair<string, StringValues> header in response.Headers)
            {
                if (_preservedHeaders.Contains(header.Key))
                {
                    headers.Add(header);
                }
            }

            response.Clear();

            foreach (KeyValuePair<string, StringValues> header in headers)
            {
                response.Headers.Add(header);
            }
        }
    }

    public static class ExceptionHandlingMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomizedExceptionHandling(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ErrorHandlingMiddleware>();
        }
    }
}
