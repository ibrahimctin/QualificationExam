using Microsoft.Extensions.Configuration;
using QualificationExam.Domain.Options;

namespace QualificationExam.Identity.Configurators
{
    public static class IdentityServiceLayerConfigurator
    {
        public static IServiceCollection LoadIdentityServices (this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICurrentUserService, CurrentUserService>();
            services.AddScoped<IJwtTokenService, JwtTokenService>();
            services.AddScoped<IRefreshTokenService, RefreshTokenService>();
        
            return services;
        }

    }
}
