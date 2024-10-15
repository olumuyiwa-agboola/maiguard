using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maiguard.Core.AppSettings
{
    /// <summary>
    /// </summary>
    public class DbConnectionSettings
    {
        /// <summary>
        /// </summary>
        public const string ConnectionStrings = "ConnectionStrings";

        /// <summary>
        /// </summary>
        public required string MaiguardSqlServerDb { get; set; }
    }
}
