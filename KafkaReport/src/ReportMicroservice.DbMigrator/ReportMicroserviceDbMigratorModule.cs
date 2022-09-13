using ReportMicroservice.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace ReportMicroservice.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(ReportMicroserviceEntityFrameworkCoreModule),
    typeof(ReportMicroserviceApplicationContractsModule)
    )]
public class ReportMicroserviceDbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
    }
}
