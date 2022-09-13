using System.Threading.Tasks;

namespace ContactService.Data;

public interface IContactServiceDbSchemaMigrator
{
    Task MigrateAsync();
}
