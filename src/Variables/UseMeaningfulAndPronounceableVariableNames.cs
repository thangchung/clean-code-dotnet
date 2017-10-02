using System;

namespace CleanCodeDotNet.Variables
{
    public class UseMeaningfulAndPronounceableVariableNames
    {
        public UseMeaningfulAndPronounceableVariableNames()
        {
            // Bad
            var ymdstr = DateTime.UtcNow.ToString("MMMM dd, yyyy");

            // Good
            var currentDate = DateTime.UtcNow.ToString("MMMM dd, yyyy");
        }
    }
}
