using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace ContactService.Web;

[Dependency(ReplaceServices = true)]
public class ContactServiceBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "ContactService";
}
