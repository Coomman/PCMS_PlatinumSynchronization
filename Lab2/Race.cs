using System;
using CodeChallenge.Core;

namespace Lab2
{
    public class Race : FileTask
    {
        public class Racer :IComparable
        {
            public string Surname { get; }
            public string Country { get; }

            public Racer(string surname, string country)
            {
                Surname = surname;
                Country = country;
            }

            public int CompareTo(object obj)
            {
                if (!(obj is Racer other))
                    throw new ArgumentOutOfRangeException(nameof(obj), "Can't compare this types");

                return string.CompareOrdinal(Country, other.Country);
            }
        }

        public override void Execute()
        {
            int length = ReadInt();
            var racers = new Racer[length];

            for (int i = 0; i < length; i++)
            {
                var query = ReadLine().Split();
                racers[i] = new Racer(query[1], query[0]);
            }

            racers.MergeSort(0, length - 1);

            string lastCountry = string.Empty;
            foreach (var racer in racers)
            {
                if (lastCountry != racer.Country)
                {
                    WriteLine($"=== {racer.Country} ===");
                    lastCountry = racer.Country;
                }

                WriteLine(racer.Surname);
            }
        }
    }
}
