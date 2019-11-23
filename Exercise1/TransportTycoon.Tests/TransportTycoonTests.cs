using AutoFixture.Xunit2;
using Moq;
using System;
using TransportTycoon.Stops;
using TransportTycoon.Vehicles;
using Xunit;

namespace TransportTycoon.Tests
{
    public class TransportTycoonTests
    {
        [Theory]
        [InlineData("A", 5)]
        [InlineData("B", 5)]
        [InlineData("AB", 5)]
        [InlineData("BB", 5)]
        [InlineData("AA", 13)]
        [InlineData("ABB", 7)]
        [InlineData("BBA", 15)]
        [InlineData("AAAABBBB", 31)]
        [InlineData("AABABBAB", 33)]
        [InlineData("ABBBABAAABBB", 41)]
        public void DeliverToDestinationA(string destinations, int expected)
        {
            // arrange
            var sut = new TransportMap()
                .AddFactory(new ProductionFactory(), new[]
                    {
                        new Truck("Mitsubishi Fuso"),
                        new Truck("Volvo")
                    })
                    .AddWarehouse(new Warehouse('A'),
                        (new Port("Port", 1), new[] { new Ship("HMS Witty") }),
                        (new DestinationWarehouse("Warehouse A", 4), null))
                    .AddWarehouse(new Warehouse('B'), (new DestinationWarehouse("Warehouse B", 5), null));

            // act
            sut.DeliverAllContainers(destinations: destinations.ToCharArray());
            var actual = sut.TotalTransportationTimeSpent;

            // assert
            Assert.Equal(expected, actual);
        }

    }
}
