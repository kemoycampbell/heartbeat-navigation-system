
public class SimulateHeartBeatMonitor : IHeartBeatMonitor
{
    public event Action OnHeartBeatLost;
    public event Action OnHeartBeatRestored;

        private bool _isRunning = true;
    private bool _isLost = false;
    private readonly Random _random = new();

    public bool HeartBeat()
    {
        return _random.NextDouble() > 0.3; // 70% chance of success
        //we are not specifying the exact logic for heartbeat here, just simulating a random success or failure
        // which can be any type of possible failures such as network issues, server downtime, etc.
    }

    public async Task StartMonitoring()
    {
        Console.WriteLine("Heartbeat Monitor Started");
        int missed = 0;

        while (_isRunning)
        {
            await Task.Delay(1000); // Simulate heartbeat check every second
            bool receivedHeartBeat = HeartBeat();

            if (!receivedHeartBeat)
            {
                missed++;
                Console.WriteLine($"No heartbeat received - count:{missed}");
            }
            else
            {
                Console.WriteLine("Heartbeat Check Successful");
                missed = 0; // Reset missed count on successful heartbeat
            }

            // Check if we have missed 3 heartbeats
            if (missed >= 3 && !_isLost)
            {
                _isLost = true;
                OnHeartBeatLost?.Invoke();
                Console.WriteLine("Heartbeat Lost");
            }
            else if (_isLost && receivedHeartBeat)
            {
                _isLost = false;
                OnHeartBeatRestored?.Invoke();
                Console.WriteLine("Heartbeat Restored");
            }

        }
    }

    public void StopMonitoring()
    {
        _isRunning = false;
        Console.WriteLine("Heartbeat Monitor Stopped");
    }
}