using TransportTycoon.Vehicles;

namespace TransportTycoon.Stops
{
    public interface IStop
    {
        string Name { get; set; }
        int TravelTime { get; set; }
        ITransportVehicle AvailableVihecle { get; }

        void AddVehicle(ITransportVehicle[] vehicles);
    }
}