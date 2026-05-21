using NUnit.Framework;
using Praktica.Algorithms;
using Praktica.Models;

namespace Praktica.Tests
{
    [TestFixture]
    public class PartialSortAlgorithmTests
    {
        private PartialSortAlgorithm algorithm = null!;

        [SetUp]
        public void Setup()
        {
            algorithm = new PartialSortAlgorithm();
        }

        [Test]
        public void FindClosestDrivers_WithEmptyDriverList_ReturnsEmptyList()
        {
            // Arrange
            var drivers = new List<Driver>();
            var order = new Order(5, 5);

            // Act
            var result = algorithm.FindClosestDrivers(drivers, order);

            // Assert
            Assert.That(result, Is.Empty);
        }

        [Test]
        public void FindClosestDrivers_WithSingleDriver_ReturnsThatDriver()
        {
            // Arrange
            var drivers = new List<Driver> { new Driver(1, 0, 0) };
            var order = new Order(0, 0);

            // Act
            var result = algorithm.FindClosestDrivers(drivers, order, 1);

            // Assert
            Assert.That(result.Count, Is.EqualTo(1));
            Assert.That(result[0].Driver.Id, Is.EqualTo(1));
        }

        [Test]
        public void FindClosestDrivers_WithMultipleDrivers_ReturnsClosestFive()
        {
            // Arrange
            var drivers = new List<Driver>
            {
                new Driver(1, 0, 0),
                new Driver(2, 1, 1),
                new Driver(3, 10, 10),
                new Driver(4, 2, 2),
                new Driver(5, 3, 3),
                new Driver(6, 100, 100)
            };
            var order = new Order(0, 0);

            // Act
            var result = algorithm.FindClosestDrivers(drivers, order, 5);

            // Assert
            Assert.That(result.Count, Is.EqualTo(5));
            Assert.That(result[0].Driver.Id, Is.EqualTo(1));
            Assert.That(result, Is.Ordered.By("Distance"));
        }

        [Test]
        public void FindClosestDrivers_ReturnsCorrectDistances()
        {
            // Arrange
            var drivers = new List<Driver>
            {
                new Driver(1, 0, 0),
                new Driver(2, 3, 4)
            };
            var order = new Order(0, 0);

            // Act
            var result = algorithm.FindClosestDrivers(drivers, order, 2);

            // Assert
            Assert.That(result[0].Distance, Is.EqualTo(0));
            Assert.That(result[1].Distance, Is.EqualTo(5));
        }

        [Test]
        public void FindClosestDrivers_WithCountLargerThanDrivers_ReturnsAllDrivers()
        {
            // Arrange
            var drivers = new List<Driver>
            {
                new Driver(1, 0, 0),
                new Driver(2, 1, 1)
            };
            var order = new Order(0, 0);

            // Act
            var result = algorithm.FindClosestDrivers(drivers, order, 5);

            // Assert
            Assert.That(result.Count, Is.EqualTo(2));
        }

        [Test]
        public void FindClosestDrivers_DistancesSorted_AscendingOrder()
        {
            // Arrange
            var drivers = new List<Driver>
            {
                new Driver(1, 10, 10),
                new Driver(2, 1, 1),
                new Driver(3, 5, 5),
                new Driver(4, 2, 2)
            };
            var order = new Order(0, 0);

            // Act
            var result = algorithm.FindClosestDrivers(drivers, order, 4);

            // Assert
            for (int i = 0; i < result.Count - 1; i++)
            {
                Assert.That(result[i].Distance, Is.LessThanOrEqualTo(result[i + 1].Distance));
            }
        }

        [Test]
        public void FindClosestDrivers_LargeDataset_ReturnsCorrectCount()
        {
            // Arrange
            var drivers = new List<Driver>();
            for (int i = 0; i < 100; i++)
            {
                drivers.Add(new Driver(i, i % 10, i / 10));
            }
            var order = new Order(5, 5);

            // Act
            var result = algorithm.FindClosestDrivers(drivers, order, 5);

            // Assert
            Assert.That(result.Count, Is.EqualTo(5));
        }
    }
}