using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Kermen.HouseHold
{
    public class Program
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            List<HouseHold> kermen = new List<HouseHold>();
            int counter = 0;
            while (input != "Democracy")
            {
                counter++;
                try
                {
                    HouseHold enity = HouseHoldFactory.CreateHouseHold(input);
                    kermen.Add(enity);
                }
                catch (Exception)
                {
                   
                }
                if (input == "EVN bill")
                {
                    kermen.RemoveAll(x => !x.CanPayBills());
                    kermen.ForEach(x => x.PayBills());
                }
                else if (input == "EVN")
                {
                    Console.WriteLine("Total consumption:" +
                                      $" {kermen.Sum(x => x.Consumption)}");
                }

                if (counter % 3 == 0)
                {
                    kermen.ForEach(x => x.GetIncome());
                }
                input = Console.ReadLine();
            }

            Console.WriteLine($"Total population: {kermen.Sum(x => x.Population)}");
        }
    }
}
