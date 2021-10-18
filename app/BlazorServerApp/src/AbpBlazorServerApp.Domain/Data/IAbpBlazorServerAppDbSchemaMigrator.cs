using System.Threading.Tasks;

namespace AbpBlazorServerApp.Data
{
    public interface IAbpBlazorServerAppDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
