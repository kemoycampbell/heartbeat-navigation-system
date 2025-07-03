public abstract class BaseDataSource : INavigationDataSource
{
    protected readonly IRoutingStrategy _routing;

    public BaseDataSource(IRoutingStrategy routing)
    {
        _routing = routing;
    }

    public abstract string SourceName { get; }

    public Route GetRoute(Location origin, Location destination)
    {
        return _routing.ComputeRoute(origin, destination);
    }
    public Route UpdateRoute(Location currentLocation)
    {
        return _routing.UpdateRoute(currentLocation);
    }
}