namespace Kermen.HouseHold.Single
{
    public abstract class Single : HouseHold
    {
        protected Single(decimal income, int numberOfRooms, decimal electricityCost)
            : base(income, numberOfRooms, electricityCost)
        {
        }
    }
}