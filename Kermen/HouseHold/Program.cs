using System;
using System.Collections.Generic;
using System.Linq;

namespace Kermen.HouseHold
{
    public class Program
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            List<HouseHold> kermen = new List<HouseHold>();

            while (input != "Democracy")
            {
                HouseHoldFactory.CreateHouseHold(input);
                
                input = Console.ReadLine();
            }

            Console.WriteLine($"Total population: {kermen.Sum(x => x.Population)}");
        }
    }
}
