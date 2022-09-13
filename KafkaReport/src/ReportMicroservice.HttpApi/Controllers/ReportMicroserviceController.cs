using ReportMicroservice.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace ReportMicroservice.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class ReportMicroserviceController : AbpControllerBase
{
    protected ReportMicroserviceController()
    {
        LocalizationResource = typeof(ReportMicroserviceResource);
    }
}
