using Microsoft.EntityFrameworkCore;
using Dedsi.BasicData.Core;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Dedsi.BasicData.EntityFrameworkCore;

[ConnectionStringName(DedsiBasicDataCoreOptions.ConnectionStringName)]
public class BasicDataDbContext : AbpDbContext<BasicDataDbContext>
{

    public BasicDataDbContext(DbContextOptions<BasicDataDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureBasicData();
    }
}