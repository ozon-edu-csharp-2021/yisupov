using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;

namespace OzonEdu.MerchandiseService.Infrastructure.Middlewares
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestLoggingMiddleware> _logger;

        public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            LogRequest(context);
            await _next(context);
        }

        private void LogRequest(HttpContext context)
        {
            try
            {
                if (context.Request.ContentType == "application/grpc") return;
                
                var routeName =
                    context.GetEndpoint()?.Metadata.OfType<RouteNameMetadata>().SingleOrDefault()?.RouteName ??
                    "no route name";
                var headers = context.Request.Headers.Select(kvp => $"{kvp.Key} : {kvp.Value};");
                
                _logger.LogInformation($"Request route: {routeName}");
                _logger.LogInformation($"Headers: {headers}");
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Could not log request");
            }
        }
    }
}