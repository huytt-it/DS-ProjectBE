using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Converters;
using NSwag;
using NSwag.Generation.Processors.Security;
using System.Linq;
using Data.DataAccess;
using Microsoft.EntityFrameworkCore;
using Services.Core;

namespace TaskManagement.Extensions
{
    public static class StartupExtensions
    {
        public static void AddPostgreDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>
                (options => options.UseSqlServer(configuration.GetConnectionString("DbConnection")));

        }
        public static void ConfigSwagger(this IServiceCollection services)
        {
            services.AddOpenApiDocument(document =>
            {
                document.Title = "DS_Project Service";
                document.Version = "3.0";
                document.AddSecurity("JWT", Enumerable.Empty<string>(), new OpenApiSecurityScheme
                {
                    Type = OpenApiSecuritySchemeType.ApiKey,
                    Name = "Authorization",
                    In = OpenApiSecurityApiKeyLocation.Header,
                    Description = "Type into the textbox: Bearer {your JWT token}."
                });
                document.OperationProcessors.Add(
                    new AspNetCoreOperationSecurityScopeProcessor("JWT"));
            });
            services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                        options.SerializerSettings.Converters.Add(new StringEnumConverter()));
        }
        public static void AddBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<IBrandService, BrandService>();
            services.AddScoped<ILocationService, LocationService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IDSBuildingService, DSBuildingService>();
            services.AddScoped<IDSMonitorService, DSMonitorService>();
            services.AddScoped<IDSMediaService, DSMediaService>();
        }
    }
}
