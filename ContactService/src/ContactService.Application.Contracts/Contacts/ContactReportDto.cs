using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactService.Contacts
{
    public class ContactReportDto
    {
        public string Location { get; set; }
        public int NearbyPeopleCount { get; set; }
        public int NearbySavedPhoneCount { get; set; }
    }
}
