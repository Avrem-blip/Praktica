using Praktica.Models;

namespace Praktica.Algorithms
{
    /// <summary>
    /// Algorithm 1: Simple sorting approach
    /// Calculates distances for all drivers and sorts them.
    /// Time Complexity: O(n log n) where n is the number of drivers
    /// Space Complexity: O(n)
    /// </summary>
    public class SimpleSortingAlgorithm : IDriverMatchingAlgorithm
    {
        public List<DriverDistance> FindClosestDrivers(List<Driver> drivers, Order order, int count = 5)
        {
            if (drivers == null || drivers.Count == 0)
                return new List<DriverDistance>();

            // Calculate distances for all drivers
            var driverDistances = drivers
                .Select(driver => new DriverDistance(
                    driver,
                    CalculateDistance(driver.X, driver.Y, order.X, order.Y)
                ))
                .ToList();

            // Sort by distance and take top N
            return driverDistances
                .OrderBy(dd => dd.Distance)
                .Take(count)
                .ToList();
        }

        private double CalculateDistance(int x1, int y1, int x2, int y2)
        {
            // Euclidean distance
            return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
        }
    }
}