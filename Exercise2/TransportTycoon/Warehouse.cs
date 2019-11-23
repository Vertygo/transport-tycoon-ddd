using System;
using System.Collections.Generic;
using System.Linq;
using TransportTycoon.Stops;

namespace TransportTycoon
{
    public sealed class Warehouse
    {
        readonly List<IStop> stops = new List<IStop>();
        public char Name { get; set; }
        public int TravelTime => stops.Sum(s => s.TravelTime);

        public Warehouse(char name)
        {
            Name = name;
        }

        public Warehouse AddStop(IStop stop)
        {
            stops.Add(stop);
            return this;
        }

        public List<IStop> GetStops()
        {
            return stops;
        }
    }
}