using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ContactService.Data;
using Volo.Abp.DependencyInjection;

namespace ContactService.EntityFrameworkCore;

public class EntityFrameworkCoreContactServiceDbSchemaMigrator
    : IContactServiceDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreContactServiceDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the ContactServiceDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<ContactServiceDbContext>()
            .Database
            .MigrateAsync();
    }
}
