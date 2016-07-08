namespace Kermen.HouseHold
{
    public class HouseHold
    {
        private int numberOfRooms;
        private decimal electricityCost;
        private readonly decimal income;
        private decimal balance;

        protected HouseHold(decimal income, int numberOfRooms, decimal electricityCost)
        {
            balance = 0;
            this.income = income;
            this.numberOfRooms = numberOfRooms;
            this.electricityCost = electricityCost;
        }

        public virtual void ElectricityCost()
        {
            electricityCost = 20;
        }

        public virtual int Population => 1;

        public virtual decimal Consumption => numberOfRooms * electricityCost;

        public void GetIncome()
        {
            balance += income;
        }

        public bool CanPayBills()
        {
            return balance >= Consumption;
        }

        public void PayBills()
        {
            balance -= Consumption;
        }
    }
}