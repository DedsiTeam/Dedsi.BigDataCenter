using Volo.Abp.Domain.Entities;

namespace Dedsi.BigDataCenterBackgroundWorkers.Samples;

public class Sample : Entity<Guid>
{
    public string SampleName { get; set; }
}