using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using System.Linq.Dynamic.Core;
using System.Reflection;
using System.Data.Common;

namespace ContactService.Contacts
{
    public class ContactService : CrudAppService<
        Contact,
        ContactDto,
        Guid,
        PagedAndSortedResultRequestDto,
        CreateUpdateContactDto>, IContactService
    {
        private readonly IRepository<Contact> _contactRepository;
        public ContactService(IRepository<Contact, Guid> contactRepository) : base(contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task<ContactDto> GetDetails(Guid id)
        {
            var queryable = await _contactRepository.
            WithDetailsAsync(x => x.ContactInfos);
            var contact = queryable.Where(c => c.Id == id).FirstOrDefault();
            return ObjectMapper.Map<Contact,ContactDto>(contact);
        }

        public async Task<PagedResultDto<ContactDto>> GetFilteredListAsync(PagedAndSortedResultByContactInfoDto input)
        {
            var queryable = await _contactRepository.
            WithDetailsAsync(x => x.ContactInfos);

            var predicate = Helpers.PredicateBuilder.True<ContactInfo>();

            if (input.ContactType != 0)
            {
                predicate = predicate.And(i => i.ContactType == input.ContactType);
            }
            if (!string.IsNullOrWhiteSpace(input.Information))
            {
                predicate = predicate.And(i => i.Information == input.Information);
            }

            var contacts = queryable
                .Where(i => i.ContactInfos.AsQueryable().Any(predicate))
                .Select(i => i)
                .ToList();

            int count = await _contactRepository.CountAsync();

            return new PagedResultDto<ContactDto>(
                count,
                ObjectMapper.Map<List<Contact>, List<ContactDto>>(contacts)
                );
        }

        public async Task<ContactReportDto> GetReportData(string location)
        {
            var queryable = await _contactRepository.GetQueryableAsync();

            var predicate = Helpers.PredicateBuilder.True<ContactInfo>();

            predicate = predicate.And(i => i.ContactType == ContactType.Location);
            if (!string.IsNullOrWhiteSpace(location))
            {
                predicate = predicate.And(i => i.Information == location);
            }

            var contacts = queryable
                .Where(i => i.ContactInfos.AsQueryable().Any(predicate))
                .Select(i => i)
                .ToList();

            int peopleCount = contacts.Distinct().Count();


            var predicate2 = Helpers.PredicateBuilder.True<ContactInfo>();
            predicate2= predicate2.And(i => i.ContactType == ContactType.PhoneNumber);


            var phoneCount = queryable
                .Where(i => i.ContactInfos.AsQueryable().Any(predicate)).Where(i => i.ContactInfos.AsQueryable().Any(predicate2))
                .Select(i => i);
            var es = phoneCount.Count();

            var reportDto = new ContactReportDto
            {
                Location = location,
                NearbyPeopleCount = peopleCount,
                NearbySavedPhoneCount = es
            };


            return reportDto;
        }       
    }
}
