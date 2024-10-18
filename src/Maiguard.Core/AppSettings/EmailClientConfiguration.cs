using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maiguard.Core.AppSettings
{
    /// <summary>
    /// </summary>
    public class EmailClientConfiguration
    {
        /// <summary>
        /// </summary>
        public const string Options = "EmailClientConfiguration";

        /// <summary>
        /// </summary>
        public string SenderName { get; set; } = string.Empty;

        /// <summary>
        /// </summary>
        public string SenderEmail { get; set; } = string.Empty;

        /// <summary>
        /// </summary>
        public string InvitationCodeEmailSubject { get; set; } = string.Empty;

        /// <summary>
        /// </summary>
        public string Username { get; set; } = string.Empty;

        /// <summary>
        /// </summary>
        public string Password { get; set; } = string.Empty;

        /// <summary>
        /// </summary>
        public string SMTPHost { get; set; } = string.Empty;

        /// <summary>
        /// </summary>
        public int Port { get; set; }
    }
}
