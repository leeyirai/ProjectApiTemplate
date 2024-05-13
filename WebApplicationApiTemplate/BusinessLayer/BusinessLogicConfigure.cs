using Microsoft.Extensions.DependencyInjection;

namespace BusinessLayer
{
    public class BusinessLogicConfigure
    {
        public static void AddService(IServiceCollection service)
        {
            service.AddScoped<IAccountLogic, AccountLogic>();
        }
    }
}
