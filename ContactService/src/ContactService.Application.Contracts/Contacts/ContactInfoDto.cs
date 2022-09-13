using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace ContactService.Contacts
{
    public class ContactInfoDto :EntityDto<Guid>
    {
        public Guid ContactId { get; set; }
        public ContactType ContactType { get; set; }
        public string Information { get; set; }
    }
}
