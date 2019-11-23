using System.Diagnostics;

namespace TransportTycoon.Vehicles
{
    public class Ship : ITransportVehicle
    {
        private string _name;
        public bool IsAvailable => State == TransportState.Idle;
        public TransportState State { get; set; } = TransportState.Idle;
        public int TravelTime { get; set; }
        private int MovementTime = 0;
        public Ship(string name)
        {
            _name = name;
        }

        public void Move()
        {
            if (State == TransportState.Idle)
                return;

            MovementTime++;
            Debug.WriteLine($"Ship `{_name}` {State} move {MovementTime}");
            if (State == TransportState.Returning && MovementTime == TravelTime)
            {
                Debug.WriteLine($"Ship `{_name}` Returned to the port");
                State = TransportState.Idle;
                MovementTime = 0;
            }

            if (State == TransportState.Transporting && MovementTime == TravelTime)
            {
                Debug.WriteLine($"Ship `{_name}` returning");
                State = TransportState.Returning;
                MovementTime = 0;
            }


        }
    }
}