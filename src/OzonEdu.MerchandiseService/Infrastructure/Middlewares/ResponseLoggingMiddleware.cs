using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;

namespace OzonEdu.MerchandiseService.Infrastructure.Middlewares
{
    public class ResponseLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestLoggingMiddleware> _logger;

        public ResponseLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await _next(context);
            LogResponse(context);
        }

        private void LogResponse(HttpContext context)
        {
            try
            {
                if (context.Response.ContentType == "application/grpc") return;
                
                var routeName =
                    context.GetEndpoint()?.Metadata.OfType<RouteNameMetadata>().SingleOrDefault()?.RouteName ??
                    "no route name";
                var headers = context.Response.Headers.Select(kvp => $"{kvp.Key} : {kvp.Value};");
                
                _logger.LogInformation($"Response route: {routeName}");
                _logger.LogInformation($"Headers: {headers}");
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Could not log response");
            }
        }
    }
}