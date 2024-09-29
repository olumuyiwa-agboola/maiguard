using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maiguard.Core.Utilities
{
    internal static class ResidentUtilities
    {
        internal static string GenerateResidentId(string communityId)
        {
            Random random = new();
            string residentId = string.Empty;
            int communityIdLength = communityId.Length;

            StringBuilder residentIdBuilder = new();
            residentIdBuilder.Append("R");
            residentIdBuilder.Append(communityId.Substring(communityIdLength - 5));

            for (int i = 0; i < 4; i++)
            {
                residentIdBuilder.Append(random.Next(0, 10).ToString());
            }

            residentId = residentIdBuilder.ToString();
            return residentId;
        }
    }
}
