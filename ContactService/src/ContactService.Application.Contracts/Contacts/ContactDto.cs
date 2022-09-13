using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace ContactService.Contacts
{
    public class ContactDto : AuditedEntityDto<Guid>
    {
        public ICollection<ContactInfoDto> ContactInfos { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
    }
}
