using ReportMicroservice.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace ReportMicroservice.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class ReportMicroservicePageModel : AbpPageModel
{
    protected ReportMicroservicePageModel()
    {
        LocalizationResourceType = typeof(ReportMicroserviceResource);
    }
}
