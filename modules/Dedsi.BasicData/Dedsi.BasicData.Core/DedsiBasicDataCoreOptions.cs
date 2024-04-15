namespace Dedsi.BasicData.Core;

public class DedsiBasicDataCoreOptions
{
    public const string RemoteServiceName = "BasicData";

    public const string ModuleName = "basicData";
    
    public static string DbTablePrefix { get; set; } = "BasicData";

    public static string? DbSchema { get; set; } = null;

    public const string ConnectionStringName = "BasicDataDB";
    
}