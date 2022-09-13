using System;
using System.Collections.Generic;
using System.Text;

namespace ReportMicroservice.Reports
{
    public class CreateUpdateReportDto
    {
        public ReportState ReportState { get; set; }
        public string ReportURL { get; set; }
    }
}
