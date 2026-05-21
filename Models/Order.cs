namespace Praktica.Models
{
    /// <summary>
    /// Represents an order with a location on the grid.
    /// </summary>
    public class Order
    {
        /// <summary>
        /// X coordinate of the order (0 <= X < N).
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Y coordinate of the order (0 <= Y < M).
        /// </summary>
        public int Y { get; set; }

        public Order(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return $"Order(X={X}, Y={Y})";
        }
    }
}