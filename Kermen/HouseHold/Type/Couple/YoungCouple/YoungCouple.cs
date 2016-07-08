namespace Kermen.HouseHold.Couple.YoungCouple
{
    public class YoungCouple : Couple
    {
        private const int NumberOfRooms = 2;
        private const int RoomElectricity = 20;

        private decimal laptopCost;

        public YoungCouple(decimal salaryOne, decimal salarayTwo,decimal tvCost, decimal fridgeCost, decimal laptopCost)
            : base(NumberOfRooms, RoomElectricity, salarayTwo + salaryOne, tvCost, fridgeCost)
        {
            this.laptopCost = laptopCost;
        }

        protected YoungCouple(int numberOfRooms, decimal roomElectricity, decimal income, decimal tvCost,
            decimal fridgeCost, decimal laptopCost) 
            : base(numberOfRooms, roomElectricity, income, tvCost, fridgeCost)
        {
            this.laptopCost = laptopCost;
        }
      
        public override decimal Consumption
        {
            get { return laptopCost += base.Consumption; }
        }
    }
}