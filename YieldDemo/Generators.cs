using System.Collections.Generic;

namespace YieldDemo
{
    public class Generators
    {
        public static IEnumerable<int> GetPrimeNumber()
        {
            int counter = 1;
            while (true)
            {
                if (IsPrimeNumber(counter))
                {
                    yield return counter;
                }
                counter++;
            }
        }

        private static bool IsPrimeNumber(int value)
        {
            bool output = true;
            for (int i = 2; i < value / 2; i++)
            {
                if (value % i == 0)
                {
                    output = false;
                    break;
                }
            }
            return output;
        }
    }
}
