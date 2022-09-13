using System;
using System.Collections.Generic;
using System.Text;

namespace ContactService.Contacts
{
    public class CreateUpdateContactInfoDto
    {
        public Guid ContactId { get; set; }
        public ContactType ContactType { get; set; }
        public string Information { get; set; }
    }
}
