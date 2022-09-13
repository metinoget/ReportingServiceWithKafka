using System;
using System.Collections.Generic;
using System.Text;

namespace ContactService.Contacts
{
    public class CreateUpdateContactDto
    {
        public ICollection<ContactInfoDto> ContactInfos { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
    }
}
