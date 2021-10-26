using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using OzonEdu.MerchandiseService.Infrastructure.Middlewares;
using OzonEdu.StockApi.Infrastructure.Middlewares;

namespace OzonEdu.MerchandiseService.Infrastructure.StartupFilters
{
    public class TerminalStartupFilter : IStartupFilter
    {
        public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
        {
            return app =>
            {
                app.Map("/version", builder => builder.UseMiddleware<VersionMiddleware>());
                app.Map("/ready", builder => builder.UseMiddleware<AliveMiddleware>());
                app.Map("/live", builder => builder.UseMiddleware<AliveMiddleware>());
                app.UseMiddleware<RequestLoggingMiddleware>();
                app.UseMiddleware<ResponseLoggingMiddleware>();
                next(app);
            };
        }
    }
}