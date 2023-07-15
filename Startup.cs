using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;
using Commander.Src.Feature.Cmd.Domain.UseCase;
using Commander.Src.Feature.Cmd.Data.DataSource;
using Commander.Src.Feature.Cmd.Domain.Repository;
using Commander.Src.Feature.Cmd.Data.Repository;
using Commander.Src.Core.Database;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Commander.Src.Core.AuthCore;
using Microsoft.AspNetCore.Identity;
using Commander.Src.Feature.Auth.Domain.Entity;
using Microsoft.AspNetCore.Http;
using Commander.Src.Core.AuthCore.JWTModels;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Commander.Src.Feature.Auth.Data.DataSource;
using Commander.Src.Feature.Auth.Domain.Repository;
using Commander.Src.Feature.Auth.Data.Repository;

namespace Commander
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DataBaseContext>(options => options.UseSqlServer(Configuration.GetConnectionString("CommanderConnection")));
            services.AddControllers().AddNewtonsoftJson(newton =>
            {
                newton.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            });
            services.AddScoped<GetCommandsUseCase>();
            services.AddScoped<GetCommandByIdUseCase>();
            services.AddScoped<DeleteCommandUseCase>();
            services.AddScoped<LoginUseCase>();
            services.AddScoped<RegisterUseCase>();
            services.AddScoped<RefreshTokenUseCase>();
            services.AddSingleton<IJwtHandler, JwtHandler>();
            services.AddTransient<TokenManagerMiddleware>();
            services.AddTransient<ITokenManager, TokenManager>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IPasswordHasher<User>, PasswordHasher<User>>();
            services.AddScoped<ICommandLocalDataSource, CommandLocalDataSourceImp>();
            services.AddScoped<IAuthLocalDataSource, AuthLocalDataSource>();
            services.AddScoped<IAuthTokenLocalDataSource, AuthTokenLocalDataSource>();
            services.AddScoped<ICommandRepository, CommandRepositoryImpl>();
            services.AddScoped<IAuthRepository, AuthRepositoryImpl>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddDistributedRedisCache(r => { r.Configuration = Configuration["redis:connectionString"]; });
            var jwtSection = Configuration.GetSection("jwt");
            var jwtOptions = new JwtOptions();
            jwtSection.Bind(jwtOptions);
            services.AddAuthentication()
                .AddJwtBearer(cfg =>
                {
                    cfg.TokenValidationParameters = new TokenValidationParameters
                    {
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.SecretKey)),
                        ValidIssuer = jwtOptions.Issuer,
                        ValidateAudience = false,
                        ValidateLifetime = true
                    };
                });
            services.Configure<JwtOptions>(jwtSection);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseMiddleware<ErrorHandlerMiddleware>();


            app.UseAuthorization();

            app.UseMiddleware<TokenManagerMiddleware>();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
