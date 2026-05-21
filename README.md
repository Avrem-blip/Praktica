# Praktica - Driver Matching System

This project implements a driver matching system for ride-sharing orders using various algorithms to find the nearest available drivers.

## Project Overview

The task involves implementing multiple algorithms to find the 5 closest drivers to an order on an N×M grid. Each algorithm has different performance characteristics and trade-offs.

## Features

- **Multiple Matching Algorithms**:
  - Simple Sorting Algorithm (O(n log n))
  - Heap-Based Algorithm (O(n log k))
  - QuickSelect Algorithm (O(n) average, O(n²) worst)
  - Partial Sort Algorithm (O(n log k))

- **Comprehensive Testing**: NUnit test suite covering all algorithms
- **Performance Benchmarking**: BenchmarkDotNet benchmarks with varying dataset sizes
- **Clean Architecture**: Separation of concerns with interfaces and modular design

## Technology Stack

- **.NET 6.0**
- **C# 10**
- **NUnit 3** - Testing framework
- **BenchmarkDotNet** - Performance benchmarking

## Project Structure

```
Praktica/
├── Models/
│   ├── Driver.cs
│   ├── Order.cs
│   └── DriverDistance.cs
├── Algorithms/
│   ├── IDriverMatchingAlgorithm.cs
│   ├── SimpleSortingAlgorithm.cs
│   ├── HeapBasedAlgorithm.cs
│   ├── QuickSelectAlgorithm.cs
│   └── PartialSortAlgorithm.cs
├── Tests/
│   ├── SimpleSortingAlgorithmTests.cs
│   ├── HeapBasedAlgorithmTests.cs
│   ├── QuickSelectAlgorithmTests.cs
│   └── PartialSortAlgorithmTests.cs
├── Benchmarks/
│   └── DriverMatchingBenchmarks.cs
└── Praktica.csproj
```

## Models

### Driver
Represents a driver with:
- **Id**: Unique identifier
- **X**: X coordinate (0 ≤ X < N)
- **Y**: Y coordinate (0 ≤ Y < M)

### Order
Represents an order with:
- **X**: X coordinate (0 ≤ X < N)
- **Y**: Y coordinate (0 ≤ Y < M)

### DriverDistance
Used internally to store driver with calculated distance from order.

## Algorithms

### 1. Simple Sorting Algorithm
Calculates distances for all drivers and sorts them.
- **Time Complexity**: O(n log n)
- **Space Complexity**: O(n)
- **Use Case**: Good general-purpose algorithm, simple to understand

### 2. Heap-Based Algorithm
Uses a max-heap to efficiently track the k closest drivers.
- **Time Complexity**: O(n log k) where k is count (5)
- **Space Complexity**: O(k)
- **Use Case**: Better for very large datasets when k is small

### 3. QuickSelect Algorithm
Uses quickselect partition to find k-th smallest element.
- **Time Complexity**: O(n) average, O(n²) worst case
- **Space Complexity**: O(1) excluding result
- **Use Case**: Fast average case performance, good for random data

### 4. Partial Sort Algorithm
Uses LINQ OrderBy with Take for efficient partial sorting.
- **Time Complexity**: O(n log k)
- **Space Complexity**: O(n)
- **Use Case**: Simple and optimized for .NET, leverages framework capabilities

## Building and Running

### Build the project
```bash
dotnet build
```

### Run tests
```bash
dotnet test
```

### Run benchmarks
```bash
dotnet run -c Release --project Praktica.csproj
```

## Benchmark Results

The benchmarks compare all four algorithms with varying dataset sizes (1,000, 10,000, and 100,000 drivers).

_Benchmark results with screenshots will be added here after running the benchmarks._

## Development Workflow

This project follows Git branching best practices:
- Feature branches for new implementations
- Pull requests for code review
- Main branch always contains working code

### Current Branch
`feature/part1-driver-matching` - Implements all four algorithms with tests and benchmarks.

## Next Steps

Part 2 will extend this implementation into an ASP.NET Core Web API with endpoints for:
- Adding/updating driver locations
- Finding nearby drivers for orders
- Persistent data storage

## Contributing

When adding new algorithms:
1. Implement `IDriverMatchingAlgorithm` interface
2. Add comprehensive unit tests
3. Add benchmark comparisons
4. Document complexity analysis and use cases
