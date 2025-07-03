public class Route
{
    public List<Location> Waypoints { get; set; } = new();
    public string Source { get; set; }
    public double EstimatedTravelTimeMinutes { get; set; }
}