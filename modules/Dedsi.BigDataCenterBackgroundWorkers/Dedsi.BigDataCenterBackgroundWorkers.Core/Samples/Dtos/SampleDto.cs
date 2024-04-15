using Volo.Abp.Application.Dtos;

namespace Dedsi.BigDataCenterBackgroundWorkers.Samples;

/// <summary>
/// 
/// </summary>
public class SampleDto : EntityDto<Guid>
{
    public string SampleName { get; set; }
}