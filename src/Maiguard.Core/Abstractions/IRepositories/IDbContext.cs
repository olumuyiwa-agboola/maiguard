using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maiguard.Core.Abstractions.IRepositories
{
    public interface IDbContext
    {
        public IDbConnection MaiguardDbConnection();
    }
}
