using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace ContactService.Contacts
{
    public class PagedAndSortedResultByContactInfoDto : PagedAndSortedResultRequestDto
    {
        public ContactType ContactType { get; set; }
        public string Information { get; set; }
    }
}
