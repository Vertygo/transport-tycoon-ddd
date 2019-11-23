//using System;

//namespace TransportTycoon
//{
//    public class TransportMapBuilder
//    {
//        private TransportMap _map;
//        private Factory _factory;

//        public TransportMapBuilder()
//        {
//            _map = new TransportMap();
//        }

//        public TransportMapBuilder AddFactory()
//        {
//            _factory = new Factory();
//            _map.AddFactory(_factory);

//            return this;
//        }

//        public TransportMap Build()
//        {
//            return _map;
//        }

//        public TransportMapBuilder AddTruck(string name)
//        {
//            _factory.AddTruck(new Truck(name));
//            return this;
//        }

//        public TransportMapBuilder AddWarehouse(char name)
//        {
//            _map.AddWarehouse(new Warehouse(name));

//            return this;
//        }

//    }
//}
