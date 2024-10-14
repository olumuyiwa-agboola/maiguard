using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maiguard.Core.Utilities
{
    internal static class ResidentUtility
    {
        internal static string GenerateResidentId(string communityId)
        {
            Random random = new();
            int communityIdLength = communityId.Length;

            StringBuilder residentIdBuilder = new();
            residentIdBuilder.Append('R')
                .Append(communityId.Substring(communityIdLength - 5))
                .Append(random.Next(1000, 10000));

            return residentIdBuilder.ToString();
        }

       internal static string GenerateInvitationCode()
        {
            Random random = new();

            StringBuilder invitationCodeBuilder = new();
            invitationCodeBuilder.Append(random.Next(100001, 1000000));

            // Save invitiation code to cache

            return invitationCodeBuilder.ToString();
        }
    }
}
