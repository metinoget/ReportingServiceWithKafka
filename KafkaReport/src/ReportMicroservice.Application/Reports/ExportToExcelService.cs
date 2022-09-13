using ReportMicroservice.ContactReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace ReportMicroservice.Reports
{
    public class ExportToExcelService : ApplicationService,IExportToExcelService
    {
        public Task<byte[]> ExportToExcel(ContactReportDto source) => Task.FromResult(ExcelFileGenerator.GenerateExcelFile(source));

        public void SaveAsFile(byte[] source,string filePath) => ExcelFileGenerator.SaveByteArrayToFileWithStaticMethod(source, filePath);
    
    }
}
