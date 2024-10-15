using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maiguard.Core.AppSettings
{
    /// <summary>
    /// </summary>
    public class RedisCacheSettings
    {
        /// <summary>
        /// </summary>
        public const string Options = "RedisCacheConfiguration";
        /// <summary>
        /// </summary>
        public string InstanceName {  get; set; } = string.Empty;
        
        /// <summary>
        /// </summary>
        public int InvitationCodeAbsoluteExpiration {  get; set; }
    }
}
