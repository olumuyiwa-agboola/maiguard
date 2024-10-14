using Maiguard.Core.Abstractions.IRepositories;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using System.Data;

namespace Maiguard.Infrastructure
{
    public class DbContext : IDbContext
    {
        private readonly ConnectionStrings _connectionStrings;
        private readonly string _maiguardDbConnectionString;

        public DbContext(IOptions<ConnectionStrings> connectionStrings)
        {
            _connectionStrings = connectionStrings.Value;
            _maiguardDbConnectionString = _connectionStrings.MaiguardDb;
        }

        public IDbConnection MaiguardDbConnection() => new SqlConnection(_maiguardDbConnectionString);
    }
}
