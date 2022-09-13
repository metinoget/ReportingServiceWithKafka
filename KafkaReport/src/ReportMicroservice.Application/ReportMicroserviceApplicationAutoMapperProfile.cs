using AutoMapper;
using ReportMicroservice.Reports;

namespace ReportMicroservice;

public class ReportMicroserviceApplicationAutoMapperProfile : Profile
{
    public ReportMicroserviceApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        CreateMap<Report, ReportDto>();
        CreateMap<CreateUpdateReportDto, Report>();
    }
}
