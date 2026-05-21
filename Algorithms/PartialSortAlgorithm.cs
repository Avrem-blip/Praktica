using Praktica.Models;

namespace Praktica.Algorithms
{
    /// <summary>
    /// Algorithm 4: Partial Sort approach
    /// Uses LINQ's built-in partial sorting capabilities.
    /// Time Complexity: O(n log k) where n is the number of drivers and k is count
    /// Space Complexity: O(n)
    /// </summary>
    public class PartialSortAlgorithm : IDriverMatchingAlgorithm
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

            // Use OrderBy with Take for efficiency
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