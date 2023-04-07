namespace QualificationExam.Persistence
{
    public static class Configurator
    {
        public static IServiceCollection LoadPersistenceServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IReadRepository<>),
              typeof(ReadRepository<>));
            services.AddScoped(typeof(IWriteRepository<>),
              typeof(WriteRepository<>));
            services.AddScoped<IQuizReadRepository, QuizReadRepository>();
            services.AddScoped<IQuizWriteRepository, QuizWriteRepository>();
            services.AddScoped<IQuestionReadRepository, QuestionReadRepository>();
            services.AddScoped<IQuestionWriteRepository, QuestionWriteRepository>();
            return services;
        }
    }
}
