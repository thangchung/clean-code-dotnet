using System.Linq;

namespace CleanCodeDotNet.Variables
{
    public class AvoidMentalMapping
    {
        public AvoidMentalMapping()
        {
            // Bad
            var l = new[] { "Austin", "New York", "San Francisco" };

            for (var i = 0; i < l.Count(); i++)
            {
                var li = l[i];
                DoStuff();
                DoSomeOtherStuff();

                // ...
                // ...
                // ...
                // Wait, what is `li` for again?
                Dispatch(li);
            }

            // Good
            var locations = new[] { "Austin", "New York", "San Francisco" };

            foreach (var location in locations)
            {
                DoStuff();
                DoSomeOtherStuff();

                // ...
                // ...
                // ...
                Dispatch(location);
            }
        }

        private string DoStuff()
        {
            return "dummy";
        }

        private string DoSomeOtherStuff()
        {
            return "dummy";
        }

        private string Dispatch(string li)
        {
            return li;
        }
    }
}
