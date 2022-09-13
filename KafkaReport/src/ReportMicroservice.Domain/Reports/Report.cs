using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace ReportMicroservice.Reports
{
    public class Report : AuditedAggregateRoot<Guid>
    {
        public ReportState ReportState { get; set; }
        public string ReportURL { get; set; }
    }
}
