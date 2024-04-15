using System;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StackExchange.Redis;
using Microsoft.OpenApi.Models;
using Dedsi.BigDataCenterBackgroundWorkers.Core;
using Dedsi.BigDataCenterBackgroundWorkers.HttpApi;
using Swashbuckle.AspNetCore.SwaggerUI;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc.UI.MultiTenancy;
using Volo.Abp.AspNetCore.Serilog;
using Volo.Abp.Auditing;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Caching;
using Volo.Abp.Caching.StackExchangeRedis;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.SqlServer;
using Volo.Abp.Json;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.MultiTenancy;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement.EntityFrameworkCore;
using Volo.Abp.VirtualFileSystem;

namespace Dedsi.BigDataCenterBackgroundWorkers;

[DependsOn(
    // Dedsi.BigDataCenterBackgroundWorkers
    typeof(BigDataCenterBackgroundWorkersInfrastructureModule),
    typeof(BigDataCenterBackgroundWorkersHttpApiModule),
    
    typeof(AbpAspNetCoreMvcUiMultiTenancyModule),
    typeof(AbpAutofacModule),
    typeof(AbpCachingStackExchangeRedisModule),
    typeof(AbpEntityFrameworkCoreSqlServerModule),
    typeof(AbpAuditLoggingEntityFrameworkCoreModule),
    typeof(AbpPermissionManagementEntityFrameworkCoreModule),
    typeof(AbpSettingManagementEntityFrameworkCoreModule),
    typeof(AbpTenantManagementEntityFrameworkCoreModule),
    typeof(AbpAspNetCoreSerilogModule),
    typeof(AbpAutofacModule)
)]
public class BigDataCenterBackgroundWorkersHttpApiHostModule : AbpModule
{
    private const bool MultiTenancyConstsIsEnabled = false;

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var hostingEnvironment = context.Services.GetHostingEnvironment();
        var configuration = context.Services.GetConfiguration();

        // SqlServer
        Configure<AbpDbContextOptions>(options =>
        {
            options.UseSqlServer();
        });

        Configure<AbpMultiTenancyOptions>(options =>
        {
            options.IsEnabled = MultiTenancyConstsIsEnabled;
        });
        
        // 日志
        Configure<AbpAuditingOptions>(options =>
        {
            options.ApplicationName = DedsiBigDataCenterBackgroundWorkersCoreOptions.ModuleName;
            options.IsEnabledForGetRequests = false;
        });
        
        // 时间格式 
        Configure<AbpJsonOptions>(options =>
        {
            options.OutputDateTimeFormat = "yyyy-MM-dd HH:mm:ss";
        });

        if (hostingEnvironment.IsDevelopment())
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.ReplaceEmbeddedByPhysical<BigDataCenterBackgroundWorkersCoreModule>(Path.Combine(hostingEnvironment.ContentRootPath, string.Format("..{0}..{0}src{0}Dedsi.BigDataCenterBackgroundWorkers.Core", Path.DirectorySeparatorChar)));
                options.FileSets.ReplaceEmbeddedByPhysical<BigDataCenterBackgroundWorkersInfrastructureModule>(Path.Combine(hostingEnvironment.ContentRootPath, string.Format("..{0}..{0}src{0}Dedsi.BigDataCenterBackgroundWorkers.Infrastructure", Path.DirectorySeparatorChar)));
                options.FileSets.ReplaceEmbeddedByPhysical<BigDataCenterBackgroundWorkersHttpApiModule>(Path.Combine(hostingEnvironment.ContentRootPath, string.Format("..{0}..{0}src{0}Dedsi.BigDataCenterBackgroundWorkers.HttpApi", Path.DirectorySeparatorChar)));
            });
        }

        context.Services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc(DedsiBigDataCenterBackgroundWorkersCoreOptions.ModuleName, new OpenApiInfo {Title = DedsiBigDataCenterBackgroundWorkersCoreOptions.ModuleName + " API", Version = "v1"});
            options.DocInclusionPredicate((docName, description) => true);
            options.CustomSchemaIds(type => type.FullName);
                
            var directoryInfo = new DirectoryInfo(AppContext.BaseDirectory);
            var fileInfos = directoryInfo.GetFileSystemInfos()
                .Where(a => a.Extension == ".xml")
                .Where(a => a.Name.EndsWith("BigDataCenterBackgroundWorkers.Core.xml") || a.Name.EndsWith("HttpApi.xml"));
        
            foreach (var info in fileInfos)
            {
                var xmlPath = Path.Combine(AppContext.BaseDirectory, info.Name);
                options.IncludeXmlComments(xmlPath,true);
            }
        });
        
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Languages.Add(new LanguageInfo("zh-Hans", "zh-Hans", "简体中文"));
            options.Languages.Add(new LanguageInfo("zh-Hant", "zh-Hant", "繁體中文"));
            options.Languages.Add(new LanguageInfo("en", "en", "English"));
        });

        context.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.Authority = configuration["AuthServer:Authority"];
                options.RequireHttpsMetadata = configuration.GetValue<bool>("AuthServer:RequireHttpsMetadata");
                options.Audience = DedsiBigDataCenterBackgroundWorkersCoreOptions.ModuleName;
            });

        Configure<AbpDistributedCacheOptions>(options =>
        {
            options.KeyPrefix = DedsiBigDataCenterBackgroundWorkersCoreOptions.ModuleName + ":";
        });

        var dataProtectionBuilder = context.Services.AddDataProtection().SetApplicationName(DedsiBigDataCenterBackgroundWorkersCoreOptions.ModuleName);
        if (!hostingEnvironment.IsDevelopment())
        {
            var redis = ConnectionMultiplexer.Connect(configuration["Redis:Configuration"]!);
            dataProtectionBuilder.PersistKeysToStackExchangeRedis(redis, DedsiBigDataCenterBackgroundWorkersCoreOptions.ModuleName + "-Protection-Keys");
        }

        context.Services.AddCors(options =>
        {
            options.AddDefaultPolicy(builder =>
            {
                builder
                    .WithOrigins(
                        configuration["App:CorsOrigins"]?
                            .Split(",", StringSplitOptions.RemoveEmptyEntries)
                            .Select(o => o.RemovePostFix("/"))
                            .ToArray() ?? Array.Empty<string>()
                    )
                    .WithAbpExposedHeaders()
                    .SetIsOriginAllowedToAllowWildcardSubdomains()
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
            });
        });
    }

    public override void OnApplicationInitialization(ApplicationInitializationContext context)
    {
        var app = context.GetApplicationBuilder();
        var env = context.GetEnvironment();

        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseCorrelationId();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseCors();
        app.UseAuthentication();
        if (MultiTenancyConstsIsEnabled)
        {
            app.UseMultiTenancy();
        }
        app.UseAbpRequestLocalization();
        app.UseAuthorization();
        
        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint($"/swagger/{DedsiBigDataCenterBackgroundWorkersCoreOptions.ModuleName}/swagger.json", DedsiBigDataCenterBackgroundWorkersCoreOptions.ModuleName +" API");
            
            options.DocExpansion(DocExpansion.None);
            options.DefaultModelsExpandDepth(-1);
        });
        
        app.UseAuditing();
        app.UseAbpSerilogEnrichers();
        app.UseConfiguredEndpoints();
    }
}
