using Microsoft.Extensions.DependencyInjection;

namespace LockerEco.EcoMode
{
    public static class ServiceCollectionExtensions
    {
        public static void AddEcoMode(this IServiceCollection services)
        {
            services.AddSingleton<IEcoModeManager, EcoModeManager>();
        }
    }
}
