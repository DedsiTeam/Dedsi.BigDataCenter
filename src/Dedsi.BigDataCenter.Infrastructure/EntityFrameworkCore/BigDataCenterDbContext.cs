using Microsoft.EntityFrameworkCore;
using Dedsi.BigDataCenter.Core;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Dedsi.BigDataCenter.EntityFrameworkCore;

[ConnectionStringName(DedsiBigDataCenterCoreOptions.ConnectionStringName)]
public class BigDataCenterDbContext : AbpDbContext<BigDataCenterDbContext>
{

    public BigDataCenterDbContext(DbContextOptions<BigDataCenterDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureBigDataCenter();
    }
}