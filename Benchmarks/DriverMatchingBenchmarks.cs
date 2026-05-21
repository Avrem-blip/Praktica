using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Praktica.Algorithms;
using Praktica.Models;

namespace Praktica.Benchmarks
{
    [MemoryDiagnoser]
    [SimpleJob(warmupCount: 3, targetCount: 5)]
    public class DriverMatchingBenchmarks
    {
        private List<Driver> drivers = null!;
        private Order order = null!;

        private SimpleSortingAlgorithm simpleSortingAlgorithm = null!;
        private HeapBasedAlgorithm heapBasedAlgorithm = null!;
        private QuickSelectAlgorithm quickSelectAlgorithm = null!;
        private PartialSortAlgorithm partialSortAlgorithm = null!;

        [Params(1000, 10000, 100000)]
        public int DriverCount { get; set; }

        [GlobalSetup]
        public void Setup()
        {
            Random random = new Random(42);
            drivers = new List<Driver>();

            for (int i = 0; i < DriverCount; i++)
            {
                drivers.Add(new Driver(i, random.Next(1000), random.Next(1000)));
            }

            order = new Order(500, 500);

            simpleSortingAlgorithm = new SimpleSortingAlgorithm();
            heapBasedAlgorithm = new HeapBasedAlgorithm();
            quickSelectAlgorithm = new QuickSelectAlgorithm();
            partialSortAlgorithm = new PartialSortAlgorithm();
        }

        [Benchmark]
        public List<DriverDistance> SimpleSorting()
        {
            return simpleSortingAlgorithm.FindClosestDrivers(drivers, order, 5);
        }

        [Benchmark]
        public List<DriverDistance> HeapBased()
        {
            return heapBasedAlgorithm.FindClosestDrivers(drivers, order, 5);
        }

        [Benchmark]
        public List<DriverDistance> QuickSelect()
        {
            return quickSelectAlgorithm.FindClosestDrivers(drivers, order, 5);
        }

        [Benchmark]
        public List<DriverDistance> PartialSort()
        {
            return partialSortAlgorithm.FindClosestDrivers(drivers, order, 5);
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<DriverMatchingBenchmarks>();
        }
    }
}