
using Infrastructure.DataAction;
using Microsoft.EntityFrameworkCore;

namespace TelegrambotAPI
{
    public class Startup
    {
        public void ConfiguretionServices( IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<TelegramDb>(opt => opt.UseNpgsql("Host= ::1 ; Port=5432 ;Database = TelegramBot; User Id = postgres; Password = 2244"));
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseRouting();
            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });
        }
    }
}
