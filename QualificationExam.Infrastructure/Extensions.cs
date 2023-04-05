namespace QualificationExam.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection ConfigureInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
               options.UseSqlServer(
                   configuration.GetConnectionString("ExamConnectionString")));

            services.AddDbContext<AppDbContext>();
            return services;
        }
    }
}