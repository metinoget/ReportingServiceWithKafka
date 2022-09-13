using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Volo.Abp;

namespace ReportMicroservice;

public class ReportMicroserviceWebTestStartup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddApplication<ReportMicroserviceWebTestModule>();
    }

    public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
    {
        app.InitializeApplication();
    }
}
