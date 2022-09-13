using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Volo.Abp;

namespace ContactService;

public class ContactServiceWebTestStartup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddApplication<ContactServiceWebTestModule>();
    }

    public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
    {
        app.InitializeApplication();
    }
}
