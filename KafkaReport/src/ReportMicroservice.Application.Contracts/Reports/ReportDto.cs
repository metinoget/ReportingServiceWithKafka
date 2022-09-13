using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace ReportMicroservice.Reports
{
    public class ReportDto : AuditedEntityDto<Guid>
    {
        public ReportState ReportState { get; set; }
        public string ReportURL { get; set; }
    }
}
