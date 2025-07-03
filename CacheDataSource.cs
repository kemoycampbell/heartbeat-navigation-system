public class CacheDataSource : BaseDataSource
{
    public CacheDataSource(IRoutingStrategy routing) : base(routing) { }

    public override string SourceName => "Cache";
}