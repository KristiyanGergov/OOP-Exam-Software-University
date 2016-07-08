namespace Kermen.HouseHold.Single
{
    public class Young : Single
    {

        private const int NumberOfRooms = 1;
        private const int ElectricityCost = 10;

        private decimal laptopCost;

        public Young(decimal salary, decimal laptopCost)
            : base(salary, NumberOfRooms, ElectricityCost)
        {
            this.laptopCost = laptopCost;
        }

        public override decimal Consumption => laptopCost + base.Consumption;

    }
}