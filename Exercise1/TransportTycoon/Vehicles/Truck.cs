using System.Diagnostics;

namespace TransportTycoon.Vehicles
{
    public sealed class Truck : ITransportVehicle
    {
        private string _name;
        public TransportState State { get; set; }
        public int TravelTime { get; set; }
        public bool IsAvailable { get => State == TransportState.Idle; }

        private int MovementTime = 0;

        public Truck(string name)
        {
            _name = name;
        }

        public void Move()
        {
            if (State == TransportState.Idle)
                return;

            MovementTime++;
            Debug.WriteLine($"Truck `{_name}` {State} move {MovementTime}");
            if (State == TransportState.Returning && MovementTime == TravelTime)
            {
                Debug.WriteLine($"Truck `{_name}` returned to werhouse");
                State = TransportState.Idle;
                MovementTime = 0;
            }

            if (State == TransportState.Transporting && MovementTime == TravelTime)
            {
                Debug.WriteLine($"Truck `{_name}` returning");
                State = TransportState.Returning;
                MovementTime = 0;
            }


        }
    }
}