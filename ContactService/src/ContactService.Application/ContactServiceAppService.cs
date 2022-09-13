using System;
using System.Collections.Generic;
using System.Text;
using ContactService.Localization;
using Volo.Abp.Application.Services;

namespace ContactService;

/* Inherit your application services from this class.
 */
public abstract class ContactServiceAppService : ApplicationService
{
    protected ContactServiceAppService()
    {
        LocalizationResource = typeof(ContactServiceResource);
    }
}
