using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using TransportTycoon.Stops;
using TransportTycoon.Vehicles;

namespace TransportTycoon
{
    public class MapIternary
    {
        private readonly Queue<IStop> _stops = new Queue<IStop>();
        private ITransportVehicle vehicle;

        public bool IsCompleated { get; private set; }

        public MapIternary(ProductionFactory factory, IEnumerable<IStop> stops)
        {
            _stops.Enqueue(factory);

            foreach (var stop in stops)
            {
                _stops.Enqueue(stop);
            }
        }

        public void Update()
        {

            if (vehicle == null || vehicle.State == TransportState.Returning || vehicle.State == TransportState.Idle)
            {
                if (_stops.Count > 1 && _stops.Take(1).First().AvailableVihecle != null)
                {
                    var stop = _stops.Dequeue();

                    vehicle = stop.AvailableVihecle;
                    vehicle.State = TransportState.Transporting;
                    vehicle.TravelTime = _stops.Take(1).First().TravelTime;
                }

                if (_stops.Count == 1 && (vehicle.State == TransportState.Returning || vehicle.State == TransportState.Idle))
                {
                    Debug.WriteLine($"Finished {_stops.Take(1).First().Name}");
                    IsCompleated = true;
                }
            }

        }
    }
}