using Microsoft.EntityFrameworkCore;
using Serilog;
using StaySphere.Domain.Interfaces.Repositories;
using StaySphere.Domain.Interfaces.Services;
using StaySphere.Infrastructure.Persistence;
using StaySphere.Infrastructure.Persistence.Repositories;
using StaySphere.Services;

namespace StaySphere.Api.Extensions
{
    public static class ConfigureServicesExtensions
    {
        public static IServiceCollection ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICommonRepository, CommonRepository>();
            
            return services;
        }

        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IBookingService, BookingService>();
            services.AddScoped<IDocumentService, DocumentService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IGuestService, GuestService>();
            services.AddScoped<IPositionService, PositionService>();
            services.AddScoped<IReviewService, ReviewService>();
            services.AddScoped<IRoomService, RoomService>();

            return services;
        }
        public static IServiceCollection ConfigureLogger(this IServiceCollection services)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.Console()
                .WriteTo.File("logs/logs.txt", rollingInterval: RollingInterval.Day)
                .WriteTo.File("logs/error_.txt", Serilog.Events.LogEventLevel.Error, rollingInterval: RollingInterval.Day)
                .CreateLogger();

            return services;
        }

        public static IServiceCollection ConfigureDatabaseContext(this IServiceCollection services)
        {
            var builder = WebApplication.CreateBuilder();

            services.AddDbContext<StaySphereDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("StaySphereDb")));

            return services;
        }
    }
}
