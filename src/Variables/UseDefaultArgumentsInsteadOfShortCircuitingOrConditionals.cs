namespace CleanCodeDotNet.Variables
{
    public class UseDefaultArgumentsInsteadOfShortCircuitingOrConditionals
    {
        public UseDefaultArgumentsInsteadOfShortCircuitingOrConditionals()
        {
            CreateMicrobreweryBadWay();
            CreateMicrobreweryGoodWay();
        }

        public void CreateMicrobreweryBadWay(string name = null)
        {
            var breweryName = !string.IsNullOrEmpty(name) ? name : "Hipster Brew Co.";
            // ...
        }

        public void CreateMicrobreweryGoodWay(string breweryName = "Hipster Brew Co.")
        {
            // ...
        }
    }
}
