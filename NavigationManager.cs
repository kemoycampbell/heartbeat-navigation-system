public class NavigationManager
{
    private INavigationDataSource _dataSource;
    public NavigationManager(INavigationDataSource dataSource)
    {
        _dataSource = dataSource;
        Console.WriteLine($"Initial to data source: {dataSource.SourceName}");
    }

    public void SwitchDataSource(INavigationDataSource newDataSource)
    {
        _dataSource = newDataSource;
        Console.WriteLine($"Switched to data source: {newDataSource.SourceName}");
    }

    public void Navigate(Location origin, Location destination)
    {
        Route route = _dataSource.GetRoute(origin, destination);
        Console.WriteLine($"Navigating from {origin.Latitude}, {origin.Longitude} to {destination.Latitude}, {destination.Longitude} using {_dataSource.SourceName} data source.");
        Console.WriteLine($"Estimated travel time: {route.EstimatedTravelTimeMinutes} minutes.");
    }

    public void UpdateNavigation(Location currentLocation)
    {
        Route updatedRoute = _dataSource.UpdateRoute(currentLocation);
        Console.WriteLine($"Updating navigation at current location {currentLocation.Latitude}, {currentLocation.Longitude} using {_dataSource.SourceName} data source.");
        Console.WriteLine($"Updated estimated travel time: {updatedRoute.EstimatedTravelTimeMinutes} minutes.");
    }

}