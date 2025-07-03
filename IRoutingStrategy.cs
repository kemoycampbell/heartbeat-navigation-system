public interface IRoutingStrategy
{

    public string StrategyName { get; }
    public Route ComputeRoute(Location origin, Location destination);
    public Route UpdateRoute(Location currentLocation);


}