using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace ReportMicroservice.Reports
{
    public interface IReportService : ICrudAppService<
            ReportDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateReportDto>
    {
        Task<ReportDto> RequestNewReportAsync(ReportRequestDto dto);
    }
}
