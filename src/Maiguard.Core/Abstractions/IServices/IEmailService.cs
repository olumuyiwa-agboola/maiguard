using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maiguard.Core.Abstractions.IServices
{
    /// <summary>
    /// </summary>
    public interface IEmailService
    {
        /// <summary>
        /// </summary>
        /// <param name="invitationCode"></param>
        /// <param name="recipient"></param>
        /// <param name="recipientName"></param>
        /// <returns></returns>
        Task SendInvitationViaEmail(string invitationCode, string recipient, string recipientName);
    }
}
