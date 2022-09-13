using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace ContactService.Contacts
{
    public interface IContactInfoService : ICrudAppService<
        ContactInfoDto,
        Guid,
        PagedAndSortedResultRequestDto,
        CreateUpdateContactInfoDto>
    {

    }
}
