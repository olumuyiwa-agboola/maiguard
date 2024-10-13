using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maiguard.Core.Abstractions.IRepositories
{
    /// <summary>
    /// </summary>
    public interface IDbContext
    {
        /// <summary>
        /// </summary>
        /// <returns>IDbConnection</returns>
        public IDbConnection MaiguardDbConnection();
    }
}
