namespace Praktica.Models
{
    /// <summary>
    /// Represents a driver with calculated distance from an order.
    /// </summary>
    public class DriverDistance
    {
        public Driver Driver { get; set; }
        public double Distance { get; set; }

        public DriverDistance(Driver driver, double distance)
        {
            Driver = driver;
            Distance = distance;
        }

        public override string ToString()
        {
            return $"{Driver} - Distance: {Distance:F2}";
        }
    }
}