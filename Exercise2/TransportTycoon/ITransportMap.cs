namespace TransportTycoon
{
    public interface ITransportMap
    {
        int TotalTransportationTimeSpent { get; }

        void DeliverAllContainers(char[] destinations);
    }
}