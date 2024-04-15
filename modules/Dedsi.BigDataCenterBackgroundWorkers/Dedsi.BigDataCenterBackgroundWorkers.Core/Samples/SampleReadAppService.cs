using Mapster;
using Dedsi.BigDataCenterBackgroundWorkers.Core.Applications;

namespace Dedsi.BigDataCenterBackgroundWorkers.Samples;

public interface ISampleReadAppService
{
    Task<SampleDto> GetAsync(Guid id);
}

public class SampleReadAppService(ISampleRepository sampleRepository) : BigDataCenterBackgroundWorkersAppService, ISampleReadAppService
{
    public async Task<SampleDto> GetAsync(Guid id)
    {
        var entity = await sampleRepository.GetAsync(a => a.Id == id);

        var resultDto = entity.Adapt<SampleDto>();
        
        return resultDto;
    }
}