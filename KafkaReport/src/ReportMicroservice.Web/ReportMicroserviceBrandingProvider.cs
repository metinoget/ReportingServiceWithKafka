using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace ReportMicroservice.Web;

[Dependency(ReplaceServices = true)]
public class ReportMicroserviceBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "ReportMicroservice";
}
