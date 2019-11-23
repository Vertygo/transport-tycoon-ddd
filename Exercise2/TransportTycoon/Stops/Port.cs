using System.Collections.Generic;
using System.Linq;
using TransportTycoon.Vehicles;

namespace TransportTycoon.Stops
{
    public sealed class Port : IStop
    {
        public string Name { get; set; }
        public int TravelTime { get; set; }
        private List<ITransportVehicle> _ships = new List<ITransportVehicle>();
        public ITransportVehicle AvailableVihecle => _ships.FirstOrDefault(s => s.IsAvailable);

        public Port(string name, int travelTime)
        {
            Name = name;
            TravelTime = travelTime;
        }

        public void AddVehicle(ITransportVehicle[] vehicles)
        {
            _ships.AddRange(vehicles);
        }
    }
}