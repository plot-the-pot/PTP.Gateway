using PTP.Gateway.Services;
using PTP.Gateway.Services.Interfaces;

namespace PTP.Gateway.API.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddTransient<IAccountService, AccountService>();
        }
    }
}
