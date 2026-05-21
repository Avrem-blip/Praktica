using Praktica.Models;

namespace Praktica.Algorithms
{
    /// <summary>
    /// Interface for driver matching algorithms.
    /// </summary>
    public interface IDriverMatchingAlgorithm
    {
        /// <summary>
        /// Finds the N closest drivers to an order.
        /// </summary>
        /// <param name="drivers">List of all drivers</param>
        /// <param name="order">The order location</param>
        /// <param name="count">Number of closest drivers to find (default 5)</param>
        /// <returns>List of N closest drivers sorted by distance</returns>
        List<DriverDistance> FindClosestDrivers(List<Driver> drivers, Order order, int count = 5);
    }
}