
using Microsoft.AspNetCore.Authentication;
using Microsoft.OpenApi.Models;
using Ifrastructure.Service;
using Picture.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using ServiceStack;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Picture_UI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddIfrastuctureServices(builder.Configuration);
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();



            builder.Services.AddSwaggerGen(options =>
            {
                OpenApiSecurityScheme scheme = new OpenApiSecurityScheme()
                {
                    Description = "Micrasoft VisualStudio",
                    In = ParameterLocation.Header,
                    Name = "Micrasoft",
                  Scheme = JwtBearerDefaults.AuthenticationScheme,
                    Type = SecuritySchemeType.Http,
                    Reference = new OpenApiReference()
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = JwtBearerDefaults.AuthenticationScheme
                    }
                };

                options.SwaggerGeneratorOptions
                    .SecuritySchemes
                    .Add(JwtBearerDefaults.AuthenticationScheme, scheme);

                options.SwaggerGeneratorOptions
                    .SecurityRequirements
                    .Add(new OpenApiSecurityRequirement()
                    {
            {new OpenApiSecurityScheme(scheme), new List<string>()}
                    });
            });


            builder.Services
                .AddAuthentication(options =>
                {
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    string key = builder.Configuration.GetSection("Authentication")["SecurityKey"];
                    string issuer = builder.Configuration.GetSection("Authentication")["Issuer"];
                    string audience = builder.Configuration.GetSection("Authentication")["Audience"];
                    int expiresInMinutes = builder.Configuration.GetSection("Authentication").GetValue<int>("ExpireAtInMinutes");


                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidIssuer = issuer,
                        ValidateAudience = true,
                        ValidAudience = audience,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
                        ClockSkew = TimeSpan.Zero
                    };

                });


            builder.Services
                .AddAuthorization();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }

        private static byte[] Encoder(byte[] bytes)
        {
            throw new NotImplementedException();
        }
    }
}