using System.Threading.Tasks;

namespace ReportMicroservice.Data;

public interface IReportMicroserviceDbSchemaMigrator
{
    Task MigrateAsync();
}
