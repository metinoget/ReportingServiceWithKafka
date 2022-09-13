using Volo.Abp.Modularity;

namespace ReportMicroservice;

[DependsOn(
    typeof(ReportMicroserviceApplicationModule),
    typeof(ReportMicroserviceDomainTestModule)
    )]
public class ReportMicroserviceApplicationTestModule : AbpModule
{

}
