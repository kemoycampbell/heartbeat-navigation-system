public interface IHeartBeatMonitor
{
    public event Action OnHeartBeatLost;
    public event Action OnHeartBeatRestored;

    public Task StartMonitoring();

    public void StopMonitoring();

    public bool HeartBeat();
}