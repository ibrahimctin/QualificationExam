﻿namespace QualificationExam.Application.Configurators
{
    public static class ApplicationLayerConfigurator
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddScoped(typeof(IPipelineBehavior<,>),
                typeof(LoggingPipeLineBehavior<,>));
            return services;
        }
    }
}
