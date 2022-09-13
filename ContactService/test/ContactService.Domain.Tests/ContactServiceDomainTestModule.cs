using ContactService.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace ContactService;

[DependsOn(
    typeof(ContactServiceEntityFrameworkCoreTestModule)
    )]
public class ContactServiceDomainTestModule : AbpModule
{

}
