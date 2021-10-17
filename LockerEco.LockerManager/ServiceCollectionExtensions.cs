using LockerEco.LockerManager.Services;
using LockerEco.LockerManager.TestHelpers;
using Microsoft.Extensions.DependencyInjection;

namespace LockerEco.LockerManager
{
    public static class ServiceCollectionExtensions
    {
        public static void AddLockerManager(this IServiceCollection services)
        {
            services.AddSingleton<ILockerSystemManager, TestLockerManager>();
            services.AddTransient<IDatabaseService, TestService>();
            services.AddTransient<IEmailService, TestService>();
            services.AddTransient<IBuildingManagementService, TestService>();
        }
    }
}
