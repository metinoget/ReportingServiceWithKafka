using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace ContactService.Contacts
{
    public class ContactInfoService : CrudAppService<
        ContactInfo,
        ContactInfoDto,
        Guid,
        PagedAndSortedResultRequestDto,
        CreateUpdateContactInfoDto>, IContactInfoService
    {
        private readonly IRepository<ContactInfo> _contactInfoRepository;
        public ContactInfoService(IRepository<ContactInfo, Guid> repository) : base(repository)
        {
            _contactInfoRepository = repository;
        }
    }
}
