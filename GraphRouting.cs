public class GraphRouting : IRoutingStrategy
{
    public string StrategyName => "GraphRouting";

    //Normally we would use a graph vector and Dijkstra or A* algorithm to compute the route.
    //For simplicity, we will return a static route.

    public Route ComputeRoute(Location origin, Location destination)
    {
        return new Route
        {
            Source = StrategyName,
            Waypoints = new List<Location> { origin, destination },
            EstimatedTravelTimeMinutes = 300
        };
    }

    public Route UpdateRoute(Location currentLocation)
    {
        return ComputeRoute(currentLocation, new Location { Latitude = 40.7128, Longitude = -74.0060 });
    }
}