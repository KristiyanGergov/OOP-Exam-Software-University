using System;
using System.Linq;
using System.Text.RegularExpressions;
using Kermen.HouseHold.Couple.OldCouple;
using Kermen.HouseHold.Couple.YoungCouple;
using Kermen.HouseHold.Single;

namespace Kermen.HouseHold
{
    class HouseHoldFactory
    {
        public static HouseHold CreateHouseHold(string input)
        {
            Regex regex = new Regex(@"(\w+)\(([\d.\s,]+)\)\s*");
            MatchCollection match = regex.Matches(input);
            if (regex.IsMatch(input))
            {
                string houseHoldType = match[0].Groups[1].Value;
                if (houseHoldType == "YoungCouple")
                {
                    return CreateYoungCouple(match);
                }
                else if (houseHoldType == "YoungCoupleWithChildren")
                {
                    return CreYoungCoupleWithChildren(match);
                }
                else if (houseHoldType == "AloneYoung")
                {
                    return CreateYoung(match);
                }
                else if (houseHoldType == "OldCouple")
                {
                    return CreateOldCouple(match);
                }
                else if (houseHoldType == "AloneOld")
                {
                    return CreateOld(match);
                }
                else
                {
                    throw new ArgumentException();
                }
            }
            throw new ArgumentException("Invalid household");
        }

        private static HouseHold CreateOld(MatchCollection match)
        {
            decimal pension = decimal.Parse(match[0].Groups[2].Value);
            return new Old(pension);
        }

        private static HouseHold CreateOldCouple(MatchCollection match)
        {
            decimal[] pensions = match[0].Groups[2].Value
                .Split(new char[] {' ', ','}, StringSplitOptions.RemoveEmptyEntries)
                .Select(decimal.Parse)
                .ToArray();

            decimal tvCost = decimal.Parse(match[1].Groups[2].Value);
            decimal fridgeCost = decimal.Parse(match[2].Groups[2].Value);
            decimal stoveCost = decimal.Parse(match[3].Groups[2].Value);
            return new OldCouple(pensions[0], pensions[1], tvCost, fridgeCost, stoveCost);
        }

        private static HouseHold CreateYoung(MatchCollection match)
        {
            decimal salary = decimal.Parse(match[0].Groups[2].Value);
            decimal laptopCost = decimal.Parse(match[1].Groups[2].Value);

            return new Young(salary, laptopCost);
        }

        private static HouseHold CreYoungCoupleWithChildren(MatchCollection match)
        {
            decimal[] salaries = match[0].Groups[2].Value
                .Split(new char[] {' ', ','}, StringSplitOptions.RemoveEmptyEntries)
                .Select(decimal.Parse)
                .ToArray();

            decimal tvCost = decimal.Parse(match[1].Groups[2].Value);
            decimal fridgeCost = decimal.Parse(match[2].Groups[2].Value);
            decimal laptopCost = decimal.Parse(match[3].Groups[2].Value);

            Child[] children = new Child[match.Count - 4];

            for (int i = 4; i < match.Count; i++)
            {
                decimal[] consumptions = match[0].Groups[2].Value
                    .Split(new char[] {' ', ','}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(decimal.Parse)
                    .ToArray();
                children[i - 4] = new Child(consumptions);
            }
            return new YoungCoupleWithChildren(salaries[0], salaries[1], tvCost, fridgeCost, laptopCost, children);
        }

        private static HouseHold CreateYoungCouple(MatchCollection match)
        {
            decimal[] salaries = match[0].Groups[2].Value
                .Split(new char[] {' ', ','}, StringSplitOptions.RemoveEmptyEntries)
                .Select(decimal.Parse)
                .ToArray();

            decimal tvCost = decimal.Parse(match[1].Groups[2].Value);
            decimal fridgeCost = decimal.Parse(match[2].Groups[2].Value);
            decimal laptopCost = decimal.Parse(match[3].Groups[2].Value);

            return new YoungCouple(salaries[0], salaries[1], tvCost, fridgeCost, laptopCost);
        }
    }
}
