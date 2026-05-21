namespace Praktica.Models
{
    /// <summary>
    /// Represents a driver's location on a grid.
    /// </summary>
    public class Driver
    {
        /// <summary>
        /// Unique identifier for the driver.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// X coordinate of the driver (0 <= X < N).
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Y coordinate of the driver (0 <= Y < M).
        /// </summary>
        public int Y { get; set; }

        public Driver(int id, int x, int y)
        {
            Id = id;
            X = x;
            Y = y;
        }

        public override bool Equals(object? obj)
        {
            if (obj is Driver other)
            {
                return Id == other.Id && X == other.X && Y == other.Y;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, X, Y);
        }

        public override string ToString()
        {
            return $"Driver(Id={Id}, X={X}, Y={Y})";
        }
    }
}