using Praktica.Models;

namespace Praktica.Algorithms
{
    /// <summary>
    /// Algorithm 2: Heap-based approach
    /// Uses a min-heap to efficiently find the N closest drivers.
    /// Time Complexity: O(n log k) where n is the number of drivers and k is count
    /// Space Complexity: O(k)
    /// </summary>
    public class HeapBasedAlgorithm : IDriverMatchingAlgorithm
    {
        public List<DriverDistance> FindClosestDrivers(List<Driver> drivers, Order order, int count = 5)
        {
            if (drivers == null || drivers.Count == 0)
                return new List<DriverDistance>();

            // Use a max heap (priority queue with reverse order) to keep track of k smallest distances
            var maxHeap = new PriorityQueue<DriverDistance, double>();

            foreach (var driver in drivers)
            {
                double distance = CalculateDistance(driver.X, driver.Y, order.X, order.Y);
                var driverDistance = new DriverDistance(driver, distance);

                if (maxHeap.Count < count)
                {
                    maxHeap.Enqueue(driverDistance, -distance); // Negative for max heap
                }
                else if (distance < -maxHeap.Peek().Priority)
                {
                    maxHeap.Dequeue();
                    maxHeap.Enqueue(driverDistance, -distance);
                }
            }

            var result = new List<DriverDistance>();
            while (maxHeap.Count > 0)
            {
                result.Add(maxHeap.Dequeue());
            }

            result.Reverse();
            result.Sort((a, b) => a.Distance.CompareTo(b.Distance));
            return result;
        }

        private double CalculateDistance(int x1, int y1, int x2, int y2)
        {
            // Euclidean distance
            return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
        }
    }
}