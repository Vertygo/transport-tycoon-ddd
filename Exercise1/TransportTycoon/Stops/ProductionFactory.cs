using System.Collections.Generic;
using System.Linq;
using TransportTycoon.Vehicles;

namespace TransportTycoon.Stops
{
    public sealed class ProductionFactory : IStop
    {
        private List<ITransportVehicle> _trucks = new List<ITransportVehicle>();
        public string Name { get; set; }
        public int TravelTime { get; set; } = 0;
        public ITransportVehicle AvailableVihecle => _trucks.FirstOrDefault(t => t.IsAvailable);

        public ProductionFactory()
        {
            Name = "Factory";
        }

        public void AddVehicle(ITransportVehicle[] vehicles)
        {
            _trucks.AddRange(vehicles);
        }
    }
}