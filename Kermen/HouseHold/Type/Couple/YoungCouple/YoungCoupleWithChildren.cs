using System.Linq;

namespace Kermen.HouseHold.Couple.YoungCouple
{
    public class YoungCoupleWithChildren : YoungCouple
    {
        private const int NumberOfRooms = 2;
        private const decimal RoomElectricity = 30;
        private Child[] children;

        public YoungCoupleWithChildren(decimal salaryOne, decimal salarayTwo, decimal tvCost, decimal fridgeCost, decimal laptopCost, Child[] children)
            : base(NumberOfRooms, RoomElectricity, salaryOne + salarayTwo, tvCost, fridgeCost, laptopCost)
        {
            this.children = children;
        }

        public override decimal Consumption
        {
            get { return children.Sum(x => x.GetTotalConsumption()) + base.Consumption; }
        }

        public override int Population => children.Length + base.Population;
    }
}