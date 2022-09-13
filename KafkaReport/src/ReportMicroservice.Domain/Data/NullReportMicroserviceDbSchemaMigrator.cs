using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace ReportMicroservice.Data;

/* This is used if database provider does't define
 * IReportMicroserviceDbSchemaMigrator implementation.
 */
public class NullReportMicroserviceDbSchemaMigrator : IReportMicroserviceDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
