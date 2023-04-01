namespace QualificationExam.Persistence.Repositories.Questions
{
    public class QuestionWriteRepository : WriteRepository<Question>, IQuestionWriteRepository
    {
        public QuestionWriteRepository(AppDbContext context) : base(context)
        {
        }
    }
}
