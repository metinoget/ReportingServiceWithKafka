using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace ContactService.Data;

/* This is used if database provider does't define
 * IContactServiceDbSchemaMigrator implementation.
 */
public class NullContactServiceDbSchemaMigrator : IContactServiceDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
