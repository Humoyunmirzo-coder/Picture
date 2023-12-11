using Infrastructure.DataAction;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class Configuration
    {
        public static void AddIfrastuctureServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<TelegramDb>(options =>
            options.UseNpgsql(configuration.GetConnectionString("TelegramConfiguration")));

        }
    }
}
