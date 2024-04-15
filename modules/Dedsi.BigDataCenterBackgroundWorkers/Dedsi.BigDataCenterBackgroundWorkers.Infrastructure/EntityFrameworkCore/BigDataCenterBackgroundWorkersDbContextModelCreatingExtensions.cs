using Microsoft.EntityFrameworkCore;
using Dedsi.BigDataCenterBackgroundWorkers.Samples;
using Volo.Abp;

namespace Dedsi.BigDataCenterBackgroundWorkers.EntityFrameworkCore;

public static class BigDataCenterBackgroundWorkersDbContextModelCreatingExtensions
{
    public static void ConfigureBigDataCenterBackgroundWorkers(this ModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));

        builder.Entity<Sample>(b =>
        {
            b.ToTable("Sample", "dbo");
            b.HasKey(a => a.Id);
        });
    }
}