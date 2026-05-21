using Praktica.Models;

namespace Praktica.Algorithms
{
    /// <summary>
    /// Algorithm 3: Quickselect-based approach
    /// Uses a modified quickselect algorithm to find the k closest drivers.
    /// Time Complexity: O(n) average case, O(n²) worst case
    /// Space Complexity: O(1) excluding result list
    /// </summary>
    public class QuickSelectAlgorithm : IDriverMatchingAlgorithm
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

            int actualCount = Math.Min(count, driverDistances.Count);
            
            // Use quickselect to partition around the k-th smallest element
            QuickSelect(driverDistances, 0, driverDistances.Count - 1, actualCount - 1);

            // Sort the first k elements and return them
            var result = driverDistances.Take(actualCount).ToList();
            result.Sort((a, b) => a.Distance.CompareTo(b.Distance));
            return result;
        }

        private void QuickSelect(List<DriverDistance> list, int left, int right, int kIndex)
        {
            if (left == right)
                return;

            int pivotIndex = Partition(list, left, right);

            if (kIndex == pivotIndex)
                return;
            else if (kIndex < pivotIndex)
                QuickSelect(list, left, pivotIndex - 1, kIndex);
            else
                QuickSelect(list, pivotIndex + 1, right, kIndex);
        }

        private int Partition(List<DriverDistance> list, int left, int right)
        {
            Random random = new Random();
            int randomIndex = left + random.Next(right - left + 1);
            
            // Swap
            (list[randomIndex], list[right]) = (list[right], list[randomIndex]);

            double pivot = list[right].Distance;
            int i = left;

            for (int j = left; j < right; j++)
            {
                if (list[j].Distance < pivot)
                {
                    (list[i], list[j]) = (list[j], list[i]);
                    i++;
                }
            }

            (list[i], list[right]) = (list[right], list[i]);
            return i;
        }

        private double CalculateDistance(int x1, int y1, int x2, int y2)
        {
            // Euclidean distance
            return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
        }
    }
}