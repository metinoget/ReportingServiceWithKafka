using System;
using System.Collections.Generic;
using System.Text;

namespace ReportMicroservice.ContactReports
{
    public class ContactReportDto
    {
        public string Location { get; set; }
        public int NearbyPeopleCount { get; set; }
        public int NearbySavedPhoneCount { get; set; }
    }
}
