using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace ContactService.Contacts
{
    public class Contact: AuditedAggregateRoot<Guid>
    {
        public ICollection<ContactInfo> ContactInfos { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }

    }
}
