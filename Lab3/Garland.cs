using System;
using System.Linq;
using System.Globalization;
using CodeChallenge.Core;

namespace Lab3
{
    public class Garland : IConsoleTask
    {
        private const double Error = 0.000001;

        private static bool BuildGarland(double[] garland)
        {
            for (int i = 2; i < garland.Length; i++)
            {
                garland[i] = 2 * garland[i - 1] - garland[i - 2] + 2;

                if (garland[i] < 0)
                    return false;
            }

            return true;
        }

        public double FindFiniteHeight(int bulbCount, double initialHeight)
        {
            var garland = new double[bulbCount];

            double l = 0;
            double r = garland[0] = initialHeight;

            while (r - l > Error)
            {
                double mid = l + (r - l) / 2;
                garland[1] = mid;

                if (BuildGarland(garland))
                    r = mid;
                else
                    l = mid;
            }

            return garland.Last();
        }

        public void ExecuteConsole()
        {
            var query = Console.ReadLine().Split();

            var bulbCount = int.Parse(query[0]);
            var initialHeight = double.Parse(query[1], CultureInfo.InvariantCulture);

            var result = FindFiniteHeight(bulbCount, initialHeight);
            Console.WriteLine(result.ToString("0.##", CultureInfo.InvariantCulture));
        }
    }
}
