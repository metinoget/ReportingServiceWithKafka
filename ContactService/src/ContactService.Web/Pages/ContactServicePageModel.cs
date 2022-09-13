using ContactService.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace ContactService.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class ContactServicePageModel : AbpPageModel
{
    protected ContactServicePageModel()
    {
        LocalizationResourceType = typeof(ContactServiceResource);
    }
}
