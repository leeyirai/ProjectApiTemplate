using Microsoft.Extensions.DependencyInjection;

namespace DataLayer
{
    public class DataManagerConfigure
    {
        public static void AddService(IServiceCollection service)
        {
            service.AddScoped<IAccountManager, AccountManager>();
        }
    }
}
