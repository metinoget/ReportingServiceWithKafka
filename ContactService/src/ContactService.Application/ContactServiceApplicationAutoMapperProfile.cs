using AutoMapper;
using ContactService.Contacts;

namespace ContactService;

public class ContactServiceApplicationAutoMapperProfile : Profile
{
    public ContactServiceApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        CreateMap<Contact, ContactDto>();
        CreateMap<CreateUpdateContactDto, Contact>();
        CreateMap<ContactInfo, ContactInfoDto>();
        CreateMap<CreateUpdateContactInfoDto, ContactInfo>();

    }
}
