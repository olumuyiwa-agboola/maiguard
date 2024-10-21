using System.Text;

namespace Maiguard.Core.Utilities
{
    internal static class AccessCodeUtility
    {
        internal static string GenerateAccessCode()
        {
            Random random = new Random();

            StringBuilder accessCodeBuilder = new();
            accessCodeBuilder.Append(random.Next(100000, 1000000));

            return accessCodeBuilder.ToString();
        }
    }
}
