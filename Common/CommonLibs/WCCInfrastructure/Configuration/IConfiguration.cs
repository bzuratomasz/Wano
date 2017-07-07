using WCCDatabaseORM.Models.Interfaces;

namespace WCCInfrastructure.Configuration
{
    public interface IConfiguration : IDbConfiguration
    {
        string Url { get; }
        int Timer { get; }
    }
}
