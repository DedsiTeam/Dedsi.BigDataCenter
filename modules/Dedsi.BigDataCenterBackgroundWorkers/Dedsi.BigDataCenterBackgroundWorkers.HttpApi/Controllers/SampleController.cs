using Microsoft.AspNetCore.Mvc;
using Dedsi.BigDataCenterBackgroundWorkers.HttpApi;
using Dedsi.BigDataCenterBackgroundWorkers.Samples;

namespace Dedsi.BigDataCenterBackgroundWorkers.Controllers;

public class SampleController(ISampleAppService sampleAppService,ISampleReadAppService sampleReadAppService) : BigDataCenterBackgroundWorkersController
{
    /// <summary>
    /// 获得
    /// </summary>
    /// <returns></returns>
    [HttpGet("{id}")]
    public Task<SampleDto> GetAsync(Guid id) => sampleReadAppService.GetAsync(id);
}