using Maiguard.Core.Abstractions.IRepositories;
using Maiguard.Core.AppSettings;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using System.Data;

namespace Maiguard.Infrastructure
{
    public class DbContext : IDbContext
    {
        private readonly DbConnectionSettings _dbConnectionSettings;
        private readonly string _maiguardDbConnectionString;

        public DbContext(IOptions<DbConnectionSettings> dbConnectionSettings)
        {
            _dbConnectionSettings = dbConnectionSettings.Value;
            _maiguardDbConnectionString = _dbConnectionSettings.MaiguardSqlServerDb;
        }

        public IDbConnection MaiguardDbConnection() => new SqlConnection(_maiguardDbConnectionString);
    }
}
