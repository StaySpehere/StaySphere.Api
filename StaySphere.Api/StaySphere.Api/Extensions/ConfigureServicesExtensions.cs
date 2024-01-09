using Serilog;
using StaySphere.Domain.Interfaces.Repositories;
using StaySphere.Domain.Interfaces.Services;
using StaySphere.Infrastructure.Persistence.Repositories;

namespace StaySphere.Api.Extensions
{
    public static class ConfigureServicesExtensions
    {
        public static IServiceCollection ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IBookingRepository, BookingRepository>();
            services.AddScoped<IDocumentRepository, DocumentRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IGuestRepository, GuestRepository>();
            services.AddScoped<IPositionRepository, PositionRepository>();
            services.AddScoped<IReviewRepository, ReviewRepository>();
            services.AddScoped<IRoomRepository, RoomRepository>();
       
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
    }
}
