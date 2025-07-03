public interface INavigationDataSource
{
    public abstract string SourceName { get; }
    public Route GetRoute(Location origin, Location destination);
    public Route UpdateRoute(Location currentLocation);
}