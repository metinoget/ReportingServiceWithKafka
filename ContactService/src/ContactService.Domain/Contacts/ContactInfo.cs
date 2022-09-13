using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace ContactService.Contacts
{
    public class ContactInfo : AggregateRoot<Guid>
    { 
        public Guid ContactId { get; set; }
        public ContactType ContactType { get; set; }
        public string Information { get; set; }

    }
}
