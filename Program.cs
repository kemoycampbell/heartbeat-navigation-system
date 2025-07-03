IRoutingStrategy routingStrategy = new WaypointRouting(); // we will use a simple flat map routing strategy

//setup 2 data sources: celluar and cache
INavigationDataSource cellularDataSource = new CelluarDataSource(routingStrategy);
INavigationDataSource cacheDataSource = new CacheDataSource(routingStrategy);

//we will start with the cellular data source
NavigationManager navigationManager = new NavigationManager(cellularDataSource);

//setup the heartbeat monitor
IHeartBeatMonitor heartBeatMonitor = new SimulateHeartBeatMonitor();

//set the listener to switch to cache data source when heartbeat is lost
heartBeatMonitor.OnHeartBeatLost += () => navigationManager.SwitchDataSource(cacheDataSource);

//set the listener to switch back to cellular data source when heartbeat is restored
heartBeatMonitor.OnHeartBeatRestored += () => navigationManager.SwitchDataSource(cellularDataSource);

//start the monitoring
_ = Task.Run(async () =>
{
    await heartBeatMonitor.StartMonitoring();
});


// Simulate navigation from Rochester to NYC
Location origin = new Location { Latitude = 43.1566, Longitude = -77.6088 }; // Rochester
Location destination = new Location { Latitude = 40.7128, Longitude = -74.0060 }; // NYC

 navigationManager.Navigate(origin, destination);

// Simulate vehicle moving and updating location every 5 seconds
for (int i = 0; i < 12; i++)
{
    await Task.Delay(5000);

    // Simulate movement closer to NYC
    var current = new Location
    {
        Latitude = origin.Latitude - ((origin.Latitude - destination.Latitude) / 12) * i,
        Longitude = origin.Longitude - ((origin.Longitude - destination.Longitude) / 12) * i
    };

    navigationManager.UpdateNavigation(current);
}

//end the monitor
heartBeatMonitor.StopMonitoring();
