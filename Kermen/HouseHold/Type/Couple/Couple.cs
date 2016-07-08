namespace Kermen.HouseHold.Couple
{
    public abstract class Couple : HouseHold
    {

        private decimal tvCost;
        private decimal fridgeCost;



        protected Couple(int numberOfRooms, decimal electricityCost, decimal income, decimal tvCost, decimal fridgeCost)
            : base(income, numberOfRooms, electricityCost)
        {
            this.tvCost = tvCost;
            this.fridgeCost = fridgeCost;
        }

        public override int Population => 1 + base.Population;

        public override decimal Consumption => tvCost * fridgeCost * base.Consumption;

    }
}