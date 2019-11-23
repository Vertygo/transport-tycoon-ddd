namespace TransportTycoon.Vehicles
{
    public interface ITransportVehicle
    {
        bool IsAvailable { get; }
        TransportState State { get; set; }
        int TravelTime { get; set; }
        void Move();
    }

    public enum TransportState
    {
        Idle,
        Transporting,
        Returning
    }
}