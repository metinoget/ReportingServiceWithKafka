using Volo.Abp.Modularity;

namespace ContactService;

[DependsOn(
    typeof(ContactServiceApplicationModule),
    typeof(ContactServiceDomainTestModule)
    )]
public class ContactServiceApplicationTestModule : AbpModule
{

}
