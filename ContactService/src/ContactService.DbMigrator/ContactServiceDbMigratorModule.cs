using ContactService.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace ContactService.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(ContactServiceEntityFrameworkCoreModule),
    typeof(ContactServiceApplicationContractsModule)
    )]
public class ContactServiceDbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
    }
}
