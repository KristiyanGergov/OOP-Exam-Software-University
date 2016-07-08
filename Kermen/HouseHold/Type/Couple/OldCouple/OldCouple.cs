namespace Kermen.HouseHold.Couple.OldCouple
{
    public class OldCouple : Couple
    {
        public const int NumberOfRooms = 3;
        public const decimal RoomElectricity = 15;

        private decimal stoveCost;

        public OldCouple
            (decimal pensionOne, decimal pensionTwo, decimal tvCost, decimal fridgeCost, decimal stoveCost)
            : base(NumberOfRooms, RoomElectricity, pensionOne + pensionTwo, tvCost, fridgeCost)
        {
            this.stoveCost = stoveCost;
        }

        public override decimal Consumption => stoveCost + base.Consumption;
    }
}