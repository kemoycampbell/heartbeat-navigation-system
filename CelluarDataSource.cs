public class CelluarDataSource : BaseDataSource
{
    public CelluarDataSource(IRoutingStrategy routing) : base(routing) { }

    public override string SourceName => "Cellular";
}