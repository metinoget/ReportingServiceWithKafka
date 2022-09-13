using System;
using System.Collections.Generic;
using System.Text;

namespace ReportMicroservice.Reports
{
    public class ReportRequestDto
    {
        public Guid Id { get; set; }
        public string Location { get; set; }
    }
}
