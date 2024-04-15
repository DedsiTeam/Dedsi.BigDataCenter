using Microsoft.EntityFrameworkCore;
using Volo.Abp;

namespace Dedsi.BasicData.EntityFrameworkCore;

public static class BasicDataDbContextModelCreatingExtensions
{
    public static void ConfigureBasicData(this ModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));

    }
}