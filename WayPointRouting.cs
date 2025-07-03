public class WaypointRouting : IRoutingStrategy
{
    public string StrategyName => "WaypointRouting";

    public Route ComputeRoute(Location origin, Location destination)
    {
        return new Route
        {
            Source = StrategyName,
            Waypoints = new List<Location> { origin, destination },
            EstimatedTravelTimeMinutes = 310
        };
    }

    public Route UpdateRoute(Location currentLocation)
    {
        return ComputeRoute(currentLocation, new Location { Latitude = 40.7128, Longitude = -74.0060 });
    }
}