using System.Text.RegularExpressions;

namespace CleanCodeDotNet.Variables
{
    /// <summary>
    /// Reference at https://docs.microsoft.com/en-us/dotnet/standard/base-types/grouping-constructs-in-regular-expressions
    /// </summary>
    public class UseExplanatoryVariables
    {
        private const string Address = "One Infinite Loop, Cupertino 95014";

        public UseExplanatoryVariables()
        {
            var cityZipCodeRegex = @"/^[^,\]+[,\\s]+(.+?)\s*(\d{5})?$/";
            var matches = Regex.Matches(Address, cityZipCodeRegex);

            // Bad
            if (matches[0].Success == true && matches[1].Success == true)
            {
                SaveCityZipCode(matches[0].Value, matches[1].Value);
            }

            // Good
            var cityZipCodeWithGroupRegex = @"/^[^,\]+[,\\s]+(?<city>.+?)\s*(?<zipCode>\d{5})?$/";
            var matchesWithGroup = Regex.Match(Address, cityZipCodeWithGroupRegex);
            var cityGroup = matchesWithGroup.Groups["city"];
            var zipCodeGroup = matchesWithGroup.Groups["zipCode"];
            if(cityGroup.Success == true && zipCodeGroup.Success == true)
            {
                SaveCityZipCode(cityGroup.Value, zipCodeGroup.Value);
            }
        }

        private bool SaveCityZipCode(string city, string zipCode)
        {
            // do saving

            return true;
        }
    }
}
