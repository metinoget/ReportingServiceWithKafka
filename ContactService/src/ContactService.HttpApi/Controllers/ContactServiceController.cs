using ContactService.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace ContactService.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class ContactServiceController : AbpControllerBase
{
    protected ContactServiceController()
    {
        LocalizationResource = typeof(ContactServiceResource);
    }
}
