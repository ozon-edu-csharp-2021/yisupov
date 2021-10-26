using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace OzonEdu.StockApi.Infrastructure.Middlewares
{
    public class AliveMiddleware
    {
        public AliveMiddleware(RequestDelegate next)
        {
        }

        public Task Invoke(HttpContext context)
        {
            context.Response.Clear();
            context.Response.StatusCode = StatusCodes.Status200OK;
            return Task.CompletedTask;
        }
    }
}