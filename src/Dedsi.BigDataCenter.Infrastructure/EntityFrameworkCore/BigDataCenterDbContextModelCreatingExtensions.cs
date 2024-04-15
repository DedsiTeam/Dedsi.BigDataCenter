using Microsoft.EntityFrameworkCore;
using Volo.Abp;

namespace Dedsi.BigDataCenter.EntityFrameworkCore;

public static class BigDataCenterDbContextModelCreatingExtensions
{
    public static void ConfigureBigDataCenter(this ModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));
    }
}