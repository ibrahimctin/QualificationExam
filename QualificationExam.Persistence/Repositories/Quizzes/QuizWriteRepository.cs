namespace QualificationExam.Persistence.Repositories.Quizzes
{
    public class QuizWriteRepository : WriteRepository<Quiz>, IQuizWriteRepository
    {
        public QuizWriteRepository(AppDbContext context) : base(context)
        {
        }
    }
}
