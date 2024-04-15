namespace Dedsi.BigDataCenterBackgroundWorkers.Core;

public class DedsiBigDataCenterBackgroundWorkersCoreOptions
{
    public const string RemoteServiceName = "BigDataCenterBackgroundWorkers";

    public const string ModuleName = "bigDataCenterBackgroundWorkers";
    
    public static string DbTablePrefix { get; set; } = "BigDataCenterBackgroundWorkers";

    public static string? DbSchema { get; set; } = null;

    public const string ConnectionStringName = "BigDataCenterBackgroundWorkersDB";
    
}