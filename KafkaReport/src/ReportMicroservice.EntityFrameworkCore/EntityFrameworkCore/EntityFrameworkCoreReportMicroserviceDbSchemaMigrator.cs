using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ReportMicroservice.Data;
using Volo.Abp.DependencyInjection;

namespace ReportMicroservice.EntityFrameworkCore;

public class EntityFrameworkCoreReportMicroserviceDbSchemaMigrator
    : IReportMicroserviceDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreReportMicroserviceDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the ReportMicroserviceDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<ReportMicroserviceDbContext>()
            .Database
            .MigrateAsync();
    }
}
