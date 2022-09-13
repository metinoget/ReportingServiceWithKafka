using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace ContactService.Contacts
{
    public interface IContactService: ICrudAppService<
        ContactDto,
        Guid,
        PagedAndSortedResultRequestDto,
        CreateUpdateContactDto>
    {

        Task<PagedResultDto<ContactDto>> GetFilteredListAsync(PagedAndSortedResultByContactInfoDto input);

        Task<ContactReportDto> GetReportData(string location);


        Task<ContactDto> GetDetails(Guid id);
    }
}
