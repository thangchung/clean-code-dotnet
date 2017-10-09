namespace CleanCodeDotNet.Variables
{
    public class DontAddUnNeededContext
    {
        public DontAddUnNeededContext()
        {

        }
    }

    // Bad
    public class CarBadWay
    {
        public string CarMake { get; set; }
        public string CarModel { get; set; }
        public string CarColor { get; set; }

        //...
    }

    // Good
    public class CarGoodWay
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }

        //...
    }
}
