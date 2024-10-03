using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maiguard.Core.Models.Residents
{
    /// <summary>
    /// </summary>
    public class ResidentActivationRequest
    {
        /// <summary>
        /// </summary>
        public string ResidentId { get; set; } = string.Empty;

        /// <summary>
        /// </summary>
        public string ActivatedBy { get; set; } = string.Empty;
    }
}
