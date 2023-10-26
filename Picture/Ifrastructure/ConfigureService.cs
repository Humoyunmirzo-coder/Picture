using Aplication.Services;
using Ifrastructure.DataAction;
using Ifrastructure.Service;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Picture.Infrastructure.Interface;
using Picture.Infrastructure.Service;
using Picture.Infrastructure.Service.Interface;

namespace Picture.Infrastructure
{
    public static class ConfigureService
    {
        public static void AddIfrastuctureServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddScoped<ExceptionHandlerMiddleware>();
            services.AddScoped<IUserRepository, UserRepository >();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IPhotoRepository, PhotoRepostory>();
            services.AddScoped<IPhotoService, PhotoService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IFriendRepository, FriendRepository>();
            services.AddScoped<IFriendService, FriendService>();

            services.AddDbContext<DataContexts>(options =>
            options.UseNpgsql(configuration.GetConnectionString("PictureConfugretion")));

        }

    }
}
