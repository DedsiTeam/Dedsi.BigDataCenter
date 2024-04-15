using Microsoft.EntityFrameworkCore;
using Dedsi.BigDataCenterBackgroundWorkers.Core;
using Dedsi.BigDataCenterBackgroundWorkers.Samples;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Dedsi.BigDataCenterBackgroundWorkers.EntityFrameworkCore;

[ConnectionStringName(DedsiBigDataCenterBackgroundWorkersCoreOptions.ConnectionStringName)]
public class BigDataCenterBackgroundWorkersDbContext : AbpDbContext<BigDataCenterBackgroundWorkersDbContext>
{

    public DbSet<Sample> Samples { get; set; }
    
    public BigDataCenterBackgroundWorkersDbContext(DbContextOptions<BigDataCenterBackgroundWorkersDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureBigDataCenterBackgroundWorkers();
    }
}