namespace QualificationExam.Persistence.Repositories.Questions
{
    public class QuestionReadRepository : ReadRepository<Question>, IQuestionReadRepository
    {
        public QuestionReadRepository(AppDbContext context) : base(context)
        {
        }
    }
}
