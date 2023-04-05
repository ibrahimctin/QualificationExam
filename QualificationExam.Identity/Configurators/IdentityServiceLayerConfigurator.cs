using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace QualificationExam.Identity.Configurators
{
    public static class IdentityServiceLayerConfigurator
    {
        public static IServiceCollection LoadIdentityServices (this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<ICurrentUserService, CurrentUserService>();
            services.AddScoped<IJwtTokenService, JwtTokenService>();
            services.AddScoped<IRefreshTokenService, RefreshTokenService>();
        
            return services;
        }

    }
}
