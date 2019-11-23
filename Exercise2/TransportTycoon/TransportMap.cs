using System;
using System.Collections.Generic;
using System.Diagnostics;
using TransportTycoon.Stops;
using TransportTycoon.Vehicles;

namespace TransportTycoon
{
    public class TransportMap : ITransportMap
    {
        private ProductionFactory _factory;
        private Dictionary<char, Warehouse> _Warehouses = new Dictionary<char, Warehouse>();
        private List<ITransportVehicle> _vehicles = new List<ITransportVehicle>();
        public int TotalTransportationTimeSpent { get; private set; }

        public TransportMap AddFactory(ProductionFactory factory, Truck[] trucks)
        {
            if (factory is null)
            {
                throw new ArgumentNullException(nameof(factory));
            }

            _factory = factory;

            _factory.AddVehicle(trucks);
            _vehicles.AddRange(trucks);

            return this;
        }

        public TransportMap AddWarehouse(Warehouse warehouse, params (IStop stop, ITransportVehicle[] vehicles)[] stops)
        {
            _Warehouses.Add(warehouse.Name, warehouse);

            foreach (var (stop, vehicles) in stops)
            {
                warehouse.AddStop(stop);

                if (vehicles != null)
                {
                    _vehicles.AddRange(vehicles);
                    stop.AddVehicle(vehicles);
                }
            }

            return this;
        }

        public void DeliverAllContainers(char[] destinations)
        {
            var ongoingInternary = new List<MapIternary>();

            Array.ForEach(destinations, dest => ongoingInternary.Add(new MapIternary(_factory, _Warehouses[dest].GetStops())));

            while (ongoingInternary.Count > 0)
            {
                ongoingInternary.ForEach(iternary => iternary.Update());
                _vehicles.ForEach(vehicle => vehicle.Move());
                ongoingInternary.ForEach(iternary => iternary.Update());
                ongoingInternary.RemoveAll(i => i.IsCompleated);

                // tick every hour :)
                TotalTransportationTimeSpent++;
                Debug.WriteLine($"Ticket {TotalTransportationTimeSpent}");
            }
        }

    }
}