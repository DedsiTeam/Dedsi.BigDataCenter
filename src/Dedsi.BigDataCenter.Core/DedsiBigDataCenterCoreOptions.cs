namespace Dedsi.BigDataCenter.Core;

public class DedsiBigDataCenterCoreOptions
{
    public const string RemoteServiceName = "BigDataCenter";

    public const string ModuleName = "bigDataCenter";
    
    public static string DbTablePrefix { get; set; } = "BigDataCenter";

    public static string? DbSchema { get; set; } = null;

    public const string ConnectionStringName = "BigDataCenterDB";
    
}