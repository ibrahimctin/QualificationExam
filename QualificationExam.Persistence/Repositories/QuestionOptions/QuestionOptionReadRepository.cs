namespace QualificationExam.Persistence.Repositories.QuestionOptions
{
    public class QuestionOptionReadRepository : ReadRepository<QuestionOption>, IQuestionOptionReadRepository
    {
        public QuestionOptionReadRepository(AppDbContext context) : base(context)
        {
        }
    }
}
