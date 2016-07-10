namespace Kermen.HouseHold.Single
{
    public class Old : Type.Single.Single
    {
        private const int NumberOfRooms = 1;
        private const decimal RoomElectricity = 15m;


        public Old(decimal pension)
            : base(pension, NumberOfRooms, RoomElectricity)
        {
        }

    }
}