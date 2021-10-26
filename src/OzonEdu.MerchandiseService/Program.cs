using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Hosting;
using OzonEdu.MerchandiseService;
using OzonEdu.MerchandiseService.Infrastructure.Extensions;

CreateHostBuilder(args).Build().Run();

static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(webBuilder =>
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                webBuilder.ConfigureKestrel(options =>
                {
                    options.ListenLocalhost(5001, o => o.UseHttps());
                    // Setup a HTTP/2 endpoint without TLS.
                    options.ListenLocalhost(5000, o => o.Protocols =
                        HttpProtocols.Http2);
                });
            }

            webBuilder.UseStartup<Startup>();
        })
        .AddInfrastructure()
        .AddHttp();