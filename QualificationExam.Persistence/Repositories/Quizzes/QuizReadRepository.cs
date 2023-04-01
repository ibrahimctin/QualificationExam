namespace QualificationExam.Persistence.Repositories.Quizzes
{
    public class QuizReadRepository : ReadRepository<Quiz>, IQuizReadRepository
    {
        public QuizReadRepository(AppDbContext context) : base(context)
        {
        }
    }
}
