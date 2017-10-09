using System.Linq;

namespace CleanCodeDotNet.Variables
{
    public class AvoidNestingTooDeeplyReturnEarly
    {
        public AvoidNestingTooDeeplyReturnEarly()
        {
            // Bad
            IsShopOpenBadWay("friday");
            FibonacciBadWay(8);

            // Good
            IsShopOpenGoodWay("friday");
            FibonacciGoodWay(8);
        }

        private bool IsShopOpenBadWay(string day)
        {
            if (string.IsNullOrEmpty(day))
            {
                day = day.ToLower();
                if (day == "friday")
                {
                    return true;
                }
                else if (day == "saturday")
                {
                    return true;
                }
                else if (day == "sunday")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

        }

        private bool IsShopOpenGoodWay(string day)
        {
            if (string.IsNullOrEmpty(day))
            {
                return false;
            }

            var openingDays = new string[] {
                "friday", "saturday", "sunday"
            };

            return openingDays.Any(d => d == day.ToLower());
        }

        private long FibonacciBadWay(int n)
        {
            if (n < 50)
            {
                if (n != 0)
                {
                    if (n != 1)
                    {
                        return FibonacciBadWay(n - 1) + FibonacciBadWay(n - 2);
                    }
                    else
                    {
                        return 1;
                    }
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                throw new System.Exception("Not supported");
            }
        }

        private long FibonacciGoodWay(int n)
        {
            if (n == 0)
            {
                return 0;
            }

            if (n == 1)
            {
                return 1;
            }

            if (n > 50)
            {
                throw new System.Exception("Not supported");
            }

            return FibonacciGoodWay(n - 1) + FibonacciGoodWay(n - 2);
        }
    }
}
