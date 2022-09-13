using ReportMicroservice.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace ReportMicroservice;

[DependsOn(
    typeof(ReportMicroserviceEntityFrameworkCoreTestModule)
    )]
public class ReportMicroserviceDomainTestModule : AbpModule
{

}
