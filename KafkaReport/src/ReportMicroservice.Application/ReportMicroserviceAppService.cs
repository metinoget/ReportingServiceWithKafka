using System;
using System.Collections.Generic;
using System.Text;
using ReportMicroservice.Localization;
using Volo.Abp.Application.Services;

namespace ReportMicroservice;

/* Inherit your application services from this class.
 */
public abstract class ReportMicroserviceAppService : ApplicationService
{
    protected ReportMicroserviceAppService()
    {
        LocalizationResource = typeof(ReportMicroserviceResource);
    }
}
