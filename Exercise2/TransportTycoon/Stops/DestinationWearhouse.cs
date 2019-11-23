using TransportTycoon.Vehicles;

namespace TransportTycoon.Stops
{
    public sealed class DestinationWarehouse : IStop
    {
        public string Name { get; set; }
        public int TravelTime { get; set; }
        
        public ITransportVehicle AvailableVihecle => null;


        public DestinationWarehouse(string name, int travelTime)
        {
            Name = name;
            TravelTime = travelTime;
        }

        public void AddVehicle(ITransportVehicle[] vehicles)
        {
        }
    }
}